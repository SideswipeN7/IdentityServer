// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Auth.Service.DI;
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            //services.AddScoped<IdentityExpressDbContext, SqlServerIdentityDbContext>();
            #endregion

            services.UseAdminUI();
        }

        public void Configure(IApplicationBuilder app)
        {
            //TODO: Perform migrations

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

            app.UseAdminUI();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}