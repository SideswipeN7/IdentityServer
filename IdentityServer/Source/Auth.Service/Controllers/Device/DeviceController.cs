// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Service.Controllers.Consent.Models;
using Auth.Service.Controllers.Consent.ViewModels;
using Auth.Service.Controllers.Device.Models;
using Auth.Service.Controllers.Device.ViewModels;
using IdentityServer4.Configuration;
using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Quickstart.UI;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Auth.Service.Controllers.Device
{
    [Authorize]
    [SecurityHeaders]
    public class DeviceController : Controller
    {
        private readonly IDeviceFlowInteractionService _interaction;
        private readonly IEventService _events;
        private readonly IOptions<IdentityServerOptions> _options;
        private readonly ILogger<DeviceController> _logger;

        public DeviceController(
            IDeviceFlowInteractionService interaction,
            IEventService eventService,
            IOptions<IdentityServerOptions> options,
            ILogger<DeviceController> logger)
        {
            _interaction = interaction;
            _events = eventService;
            _options = options;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userCodeParamName = _options.Value.UserInteraction.DeviceVerificationUserCodeParameter;
            string userCode = Request.Query[userCodeParamName];
            if (string.IsNullOrWhiteSpace(userCode))
            {
                return View("UserCodeCapture");
            }

            DeviceAuthorizationViewModel viewModel = await BuildViewModelAsync(userCode);
            if (viewModel is null)
            {
                return View("Error");
            }

            viewModel.ConfirmUserCode = true;

            return View("UserCodeConfirmation", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserCodeCapture(string userCode)
        {
            DeviceAuthorizationViewModel viewModel = await BuildViewModelAsync(userCode);
            if (viewModel is null)
            {
                return View("Error");
            }

            return View("UserCodeConfirmation", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Callback(DeviceAuthorizationInputModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            ProcessConsentResult result = await ProcessConsent(model);
            if (result.HasValidationError)
            {
                return View("Error");
            }

            return View("Success");
        }

        private async Task<ProcessConsentResult> ProcessConsent(DeviceAuthorizationInputModel model)
        {
            ProcessConsentResult result = new();

            DeviceFlowAuthorizationRequest request = await _interaction.GetAuthorizationContextAsync(model.UserCode);
            if (request is null)
            {
                return result;
            }

            ConsentResponse grantedConsent = null;

            // user clicked 'no' - send back the standard 'access_denied' response
            if (model.Button is "no")
            {
                grantedConsent = new ConsentResponse { Error = AuthorizationError.AccessDenied };

                // emit event
                await _events.RaiseAsync(new ConsentDeniedEvent(User.GetSubjectId(), request.Client.ClientId, request.ValidatedResources.RawScopeValues));
            }
            // user clicked 'yes' - validate the data
            else if (model.Button is "yes")
            {
                // if the user consented to some scope, build the response model
                if (model.ScopesConsented is not null && model.ScopesConsented.Any())
                {
                    IEnumerable<string> scopes = model.ScopesConsented;
                    if (!ConsentOptions.EnableOfflineAccess)
                    {
                        scopes = scopes.Where(x => x != IdentityServer4.IdentityServerConstants.StandardScopes.OfflineAccess);
                    }

                    grantedConsent = new()
                    {
                        RememberConsent = model.RememberConsent,
                        ScopesValuesConsented = scopes.ToArray(),
                        Description = model.Description,
                    };

                    // emit event
                    await _events.RaiseAsync(new ConsentGrantedEvent(
                        User.GetSubjectId(),
                        request.Client.ClientId,
                        request.ValidatedResources.RawScopeValues,
                        grantedConsent.ScopesValuesConsented,
                        grantedConsent.RememberConsent));
                }
                else
                {
                    result.ValidationError = ConsentOptions.MustChooseOneErrorMessage;
                }
            }
            else
            {
                result.ValidationError = ConsentOptions.InvalidSelectionErrorMessage;
            }

            if (grantedConsent is not null)
            {
                // communicate outcome of consent back to identityserver
                await _interaction.HandleRequestAsync(model.UserCode, grantedConsent);

                // indicate that's it ok to redirect back to authorization endpoint
                result.RedirectUri = model.ReturnUrl;
                result.Client = request.Client;
            }
            else
            {
                // we need to redisplay the consent UI
                result.ViewModel = await BuildViewModelAsync(model.UserCode, model);
            }

            return result;
        }

        private async Task<DeviceAuthorizationViewModel> BuildViewModelAsync(string userCode, DeviceAuthorizationInputModel model = null)
        {
            DeviceFlowAuthorizationRequest request = await _interaction.GetAuthorizationContextAsync(userCode);
            if (request is not null)
            {
                return CreateConsentViewModel(userCode, model, request);
            }

            return null;
        }

        private DeviceAuthorizationViewModel CreateConsentViewModel(string userCode, DeviceAuthorizationInputModel model, DeviceFlowAuthorizationRequest request)
        {
            DeviceAuthorizationViewModel viewModel = new()
            {
                UserCode = userCode,
                Description = model?.Description,

                RememberConsent = model?.RememberConsent ?? true,
                ScopesConsented = model?.ScopesConsented ?? Enumerable.Empty<string>(),

                ClientName = request.Client.ClientName ?? request.Client.ClientId,
                ClientUrl = request.Client.ClientUri,
                ClientLogoUrl = request.Client.LogoUri,
                AllowRememberConsent = request.Client.AllowRememberConsent
            };

            viewModel.IdentityScopes = request.ValidatedResources.Resources.IdentityResources.Select(identityResource =>
                CreateScopeViewModel(
                        identityResource,
                        viewModel.ScopesConsented.Contains(identityResource.Name) || model is null)
                ).ToArray();

            List<ScopeViewModel> apiScopes = new();
            foreach (var parsedScope in request.ValidatedResources.ParsedScopes)
            {
                ApiScope apiScope = request.ValidatedResources.Resources.FindApiScope(parsedScope.ParsedName);
                if (apiScope != null)
                {
                    ScopeViewModel scopeViewModel = CreateScopeViewModel(
                        parsedScope,
                        apiScope,
                        viewModel.ScopesConsented.Contains(parsedScope.RawValue) || model == null);

                    apiScopes.Add(scopeViewModel);
                }
            }
            if (ConsentOptions.EnableOfflineAccess && request.ValidatedResources.Resources.OfflineAccess)
            {
                apiScopes.Add(GetOfflineAccessScope(viewModel.ScopesConsented.Contains(IdentityServer4.IdentityServerConstants.StandardScopes.OfflineAccess) || model == null));
            }

            viewModel.ApiScopes = apiScopes;

            return viewModel;
        }

        private ScopeViewModel CreateScopeViewModel(IdentityResource identity, bool check) => new()
        {
            Value = identity.Name,
            DisplayName = identity.DisplayName ?? identity.Name,
            Description = identity.Description,
            Emphasize = identity.Emphasize,
            Required = identity.Required,
            Checked = check || identity.Required
        };

        public ScopeViewModel CreateScopeViewModel(ParsedScopeValue parsedScopeValue, ApiScope apiScope, bool check) => new()
        {
            Value = parsedScopeValue.RawValue,
            // todo: use the parsed scope value in the display?
            DisplayName = apiScope.DisplayName ?? apiScope.Name,
            Description = apiScope.Description,
            Emphasize = apiScope.Emphasize,
            Required = apiScope.Required,
            Checked = check || apiScope.Required
        };

        private ScopeViewModel GetOfflineAccessScope(bool check) => new()
        {
            Value = IdentityServer4.IdentityServerConstants.StandardScopes.OfflineAccess,
            DisplayName = ConsentOptions.OfflineAccessDisplayName,
            Description = ConsentOptions.OfflineAccessDescription,
            Emphasize = true,
            Checked = check
        };
    }
}