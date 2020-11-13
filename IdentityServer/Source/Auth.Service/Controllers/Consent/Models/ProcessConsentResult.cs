// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Auth.Service.Controllers.Consent.ViewModels;
using IdentityServer4.Models;

namespace Auth.Service.Controllers.Consent.Models
{
    public class ProcessConsentResult
    {
        public bool IsRedirect => RedirectUri is not null;

        public string RedirectUri { get; set; }

        public Client Client { get; set; }

        public bool ShowView => ViewModel is not null;

        public ConsentViewModel ViewModel { get; set; }

        public bool HasValidationError => ValidationError is not null;

        public string ValidationError { get; set; }
    }
}