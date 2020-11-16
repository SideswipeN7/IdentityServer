using Auth.Identity.Database;
using Auth.Identity.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Service.DI
{
    public static class AspIdentityConfiguration
    {
        public static void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Identity")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                //.AddEntityFrameworkStores<IdentityContext>() // OR USE PersistedGrantContext
                .AddDefaultTokenProviders();
        }
    }
}