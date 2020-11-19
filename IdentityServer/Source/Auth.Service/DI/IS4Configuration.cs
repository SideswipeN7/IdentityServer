using Auth.Configurations.Database;
using Auth.Configurations.Migrations;
using Auth.Grants.Database;
using Auth.Grants.Migrations;
using Auth.Identity.Database.Models;
using IdentityServer4.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Service.DI
{
    public static class IS4Configuration
    {
        public static void Register(IConfiguration configuration, IServiceCollection services)
        {
            string connectionStringConfigurationDb = configuration.GetConnectionString("Configuration");
            string configurationMigrationsAssembly = typeof(ConfigurationContextModelSnapshot).Assembly.FullName;

            string connectionStringGrantDb = configuration.GetConnectionString("PersistedGrant");
            string grantMigrationsAssembly = typeof(PersistedGrantContextModelSnapshot).Assembly.FullName;

            IIdentityServerBuilder builder = services.AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;

                    options.UserInteraction = new UserInteractionOptions
                    {
                        LogoutUrl = "/Account/Logout",
                        LoginUrl = "/Account/Login",
                        LoginReturnUrlParameter = "returnUrl"
                    };
                })
                .AddAspNetIdentity<ApplicationUser>()
                // this adds the config data from DB (clients, resources, CORS)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = db =>
                        db.UseSqlServer(connectionStringConfigurationDb,
                            sql => sql.MigrationsAssembly(configurationMigrationsAssembly));
                })
                // this adds the operational data from DB (codes, tokens, consents)
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = db =>
                        db.UseSqlServer(connectionStringGrantDb,
                            sql => sql.MigrationsAssembly(grantMigrationsAssembly));

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    // options.TokenCleanupInterval = 15; // interval in seconds. 15 seconds useful for debugging
                });

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            services.AddDbContext<ConfigurationContext>();
            services.AddDbContext<PersistedGrantContext>();
        }
    }
}