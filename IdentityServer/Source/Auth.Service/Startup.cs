// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using Auth.Configuration.Database;
using Auth.Grant.Database;
using Auth.Identity.Database;
using Auth.Service.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Auth.Service
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; init; }

        public IConfiguration Configuration { get; init; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration) =>
            (Environment, Configuration) = (environment, configuration);

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // Configures IIS settings
            IISConfiguration.Register(services);
            // Configure ASP Identity
            AspIdentityConfiguration.Register(Configuration, services);
            // Configure IdentityServer4
            IS4Configuration.Register(Configuration, services);
            // Configure External Authentication Providers
            ExternalProvidersConfiguration.Register(Configuration, services);

            #region toDelete
            //services.AddDbContext<IdentityContext>(options =>
            //    options.UseSqlServer(connectionStringUsersDb));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<PersistedGrantContext>()
            //    .AddDefaultTokenProviders();

            //var builder = services.AddIdentityServer(options =>
            //    {
            //        options.Events.RaiseErrorEvents = true;
            //        options.Events.RaiseInformationEvents = true;
            //        options.Events.RaiseFailureEvents = true;
            //        options.Events.RaiseSuccessEvents = true;

            //        options.UserInteraction = new UserInteractionOptions
            //        {
            //            LogoutUrl = "/Account/Logout",
            //            LoginUrl = "/Account/Login",
            //            LoginReturnUrlParameter = "returnUrl"
            //        };
            //    })
            //    .AddAspNetIdentity<ApplicationUser>()
            //    // this adds the config data from DB (clients, resources, CORS)
            //    .AddConfigurationStore(options =>
            //    {
            //        options.ConfigureDbContext = db =>
            //            db.UseSqlServer(connectionStringConfigurationDb,
            //                sql => sql.MigrationsAssembly(migrationsAssembly));
            //    })
            //    // this adds the operational data from DB (codes, tokens, consents)
            //    .AddOperationalStore(options =>
            //    {
            //        options.ConfigureDbContext = db =>
            //            db.UseSqlServer(connectionStringConfigurationDb,
            //                sql => sql.MigrationsAssembly(migrationsAssembly));

            //        // this enables automatic token cleanup. this is optional.
            //        options.EnableTokenCleanup = true;
            //        // options.TokenCleanupInterval = 15; // interval in seconds. 15 seconds useful for debugging
            //    });

            //// not recommended for production - you need to store your key material somewhere secure
            //builder.AddDeveloperSigningCredential();

            //services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

            //        options.ClientId = Configuration["Secret:GoogleClientId"];
            //        options.ClientSecret = Configuration["Secret:GoogleClientSecret"];
            //    });
            #endregion

            //services.UseAdminUI();
            //services.AddScoped<IdentityExpressDbContext, SqlServerIdentityDbContext>();
        }

        public void Configure(IApplicationBuilder app)
        {
            MigrateDatabase<IdentityContext>(app);
            MigrateDatabase<ConfigurationContext>(app);
            MigrateDatabase<PersistedGrantContext>(app);


            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();

            // app.UseAdminUI();

            //app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }

        private static void MigrateDatabase<T>(IApplicationBuilder app) where T: DbContext
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            try
            {
                var configurationContext = serviceScope.ServiceProvider.GetService<T>();
                configurationContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = serviceScope.ServiceProvider.GetService<ILogger<Startup>>();
                logger.LogError(ex, "An error occurred.");

                throw;
            }
        }
    }
}