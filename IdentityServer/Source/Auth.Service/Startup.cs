// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using Auth.Configurations.Database;
using Auth.Grants.Database;
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
        private IWebHostEnvironment Environment { get; init; }

        private IConfiguration Configuration { get; init; }

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

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
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