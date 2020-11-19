using System;
using Auth.Service.Configurations;
using IdentityServer4;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Service.DI
{
    public static class ExternalProvidersConfiguration
    {
        private const string ExternalProviderGoogle = "Google";
        public static void Register(IConfiguration configuration, IServiceCollection services)
        {
            foreach (ExternalProviderConfiguration config in configuration.GetValue<ExternalProviderConfiguration[]>("ExternalProviders"))
            {
                switch (config)
                {
                    case { Name: ExternalProviderGoogle, IsActive: true }:
                        RegisterGoogle(config, services);
                        break;
                    default: throw new ArgumentException($"Unknown external provider name: '{config.Name}'");
                }
            }
        }

        private static void RegisterGoogle(ExternalProviderConfiguration configuration, IServiceCollection services) => services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                options.ClientId = configuration.ClientId;
                options.ClientSecret = configuration.ClientSecret;
            });
    }
}