using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthenticationService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
                 .AddDeveloperSigningCredential()
                 .AddInMemoryApiResources(Config.GetAllApiResources())
                 .AddInMemoryClients(Config.GetClients())
                 .AddInMemoryIdentityResources(Config.GetIdentityResources())
                 .AddInMemoryApiScopes(Config.GetApiScopes());

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseIdentityServer();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context => await context.Response.WriteAsync("Hello World!"));
            //});
        }
    }
}