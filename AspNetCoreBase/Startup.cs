using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreBase
{
    public class Startup
    {
        static int startupStaticX = 0;

        public void ConfigureServices(IServiceCollection services)
        {
        }

        // Pipeline Configure (..., IWebHostEnvironment - optional):
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.Map("/index", ProcessAnonimous);
            // app.Map("/about", ProcessAuthorized);
            // app.MapWhen( Func<HttpContext, bool> );
            // app.Use... - Use and path request to Next.
            // app.Run... - just Run, not call Next.

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

            app.UseMiddleware<MyTokenMiddleware>();

            // To Create Middleware is using:
            //
            // public delegate Task RequestDelegate(HttpContext httpContext);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async httpContext =>
                {
                    await httpContext.Response.WriteAsync(
                        $"Current HostingEnvironment is - {env.EnvironmentName}.\r\n\r\n" +
                        $"RequestsCounter: {startupStaticX++}");
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

    internal class MyTokenMiddleware
    {
        private readonly RequestDelegate requestDelegate;

        public MyTokenMiddleware(RequestDelegate next)
        {
            requestDelegate = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["token"];
            if (token == "12345678")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid.");
            }
            else
            {
                await requestDelegate.Invoke(context);
            }
        }
    }
}
