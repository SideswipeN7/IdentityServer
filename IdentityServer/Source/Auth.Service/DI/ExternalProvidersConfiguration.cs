using System.Collections.Generic;
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
            List<ExternalProviderConfiguration> providerConfigurations = new();
            configuration.GetSection("ExternalProviders").Bind(providerConfigurations);

            foreach (ExternalProviderConfiguration config in providerConfigurations)
            {
                switch (config)
                {
                    case { Name: ExternalProviderGoogle, IsActive: true }:
                        RegisterGoogle(config, services);
                        break;
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