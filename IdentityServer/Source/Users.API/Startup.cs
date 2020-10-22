using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;
using User.API.Models;

namespace User.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            const string appName = "Users.API";

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(opts =>
                {
                    opts.Authority = "http://localhost:5000";
                    opts.RequireHttpsMetadata = false;
                    opts.ApiName = "UserAPI";
                    opts.LegacyAudienceValidation = true;
                });

            services.AddDbContext<AppDbContext>(opts => opts.UseInMemoryDatabase("devDb"));

            services.AddControllers();

            services.AddSwaggerDocument(config => {
                config.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT token"));
                config.AddSecurity("JWT token", new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    Description = "Copy 'Bearer ' + valid JWT token into field",
                    In = OpenApiSecurityApiKeyLocation.Header
                });
                config.PostProcess = (document) =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = appName;
                    document.Info.Description = $"ASP.NET 5 {appName}";
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //SWAGGER UI
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}