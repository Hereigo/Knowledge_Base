using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreBase
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // Pipeline Configure (..., IWebHostEnvironment - optional):
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.Map...
            // app.Run...
            // app.Use...

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // To Create Middleware :
            // public delegate Task RequestDelegate(HttpContext httpContext);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async httpContext =>
                {
                    await httpContext.Response.WriteAsync($"Current HostingEnvironment is - {env.EnvironmentName}");
                });
            });
        }
    }
}
