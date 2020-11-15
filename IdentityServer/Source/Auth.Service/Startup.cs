// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Auth.Configuration.Database;
using Auth.Configuration.Migrations;
using Auth.Data;
using Auth.Data.Models;
using IdentityExpress.Identity;
using IdentityExpress.Manager.Api;
using IdentityServer4;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Auth.Service
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }

        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration) =>
            (Environment, Configuration) = (environment, configuration);

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionStringUsersDb = Configuration.GetConnectionString("Users");
            string connectionStringConfigurationDb = Configuration.GetConnectionString("Configuration");
            string migrationsAssembly = typeof(ConfigurationContextModelSnapshot).Assembly.FullName;

            services.AddControllersWithViews();

            // configures IIS settings
            IISConfiguration.Register(services);

            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(connectionStringUsersDb));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<PersistedGrantContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer(options =>
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
                            sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                // this adds the operational data from DB (codes, tokens, consents)
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = db =>
                        db.UseSqlServer(connectionStringConfigurationDb,
                            sql => sql.MigrationsAssembly(migrationsAssembly));

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    // options.TokenCleanupInterval = 15; // interval in seconds. 15 seconds useful for debugging
                });

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    options.ClientId = Configuration["Secret:GoogleClientId"];
                    options.ClientSecret = Configuration["Secret:GoogleClientSecret"];
                });

            services.UseAdminUI();
            services.AddScoped<IdentityExpressDbContext, SqlServerIdentityDbContext>();
        }

        public void Configure(IApplicationBuilder app, IdentityContext identityContext, PersistedGrantContext persistedGrantContext)
        {
            //Migrations
            identityContext.Database.Migrate();
            persistedGrantContext.Database.Migrate();

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