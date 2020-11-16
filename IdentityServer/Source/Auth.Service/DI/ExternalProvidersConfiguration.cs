using IdentityServer4;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Service.DI
{
    public static class ExternalProvidersConfiguration
    {
        public static void Register(IConfiguration configuration,IServiceCollection services)
        {
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    options.ClientId = configuration["Secret:GoogleClientId"];
                    options.ClientSecret = configuration["Secret:GoogleClientSecret"];
                });
        }
    }
}