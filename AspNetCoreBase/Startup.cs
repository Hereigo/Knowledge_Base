using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreBase
{
    public class Startup
    {
        static int x = 0;

        public void ConfigureServices(IServiceCollection services)
        {
        }

        // Pipeline Configure (..., IWebHostEnvironment - optional):
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.Map... // app.Run... // app.Use...

            // app.UseAuthentication()
            // app.UseAuthorization()
            // app.UseCookiePolicy()
            // app.UseCORS()
            // app.UseDiagnostics() - add diag. status pages for dev.
            // app.UseForwardedHeaders()
            // app.UseHeaderPropagation()
            // app.UseHealthCheck()
            // app.UseHsts() -  Strict Transport Security(HSTS) add some headers for more security
            // app.UseHttpMethodOverride()
            // app.UseHttpsRedirection() - forward http to https
            // app.UseMVC()
            // app.UseRequestLocalization()
            // app.UseResponseCaching()
            // app.UseResponseCompression()
            // app.UseRewriter()
            // app.UseRouting()
            // app.UseSession()
            // app.UseStaticFiles()
            // app.UseWebSockets()

            if (env.IsDevelopment()) // in launchSettings.json or machine ENVs
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // To Create Middleware using:
            // public delegate Task RequestDelegate(HttpContext httpContext);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async httpContext =>
                {
                    await httpContext.Response.WriteAsync(
                        $"Current HostingEnvironment is - {env.EnvironmentName}.\r\n\r\n" +
                        $"RequestsCounter: {x++}");
                });
            });
            // OR :
            // int y = 2;
            // app.Run(async (context) =>
            // {
            //     y = y * 2;  //  2 * 2 = 4
            //     await context.Response.WriteAsync($"Result: {y}");
            // });
        }
    }
}
