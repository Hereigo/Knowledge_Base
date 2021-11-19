using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RedirectMiddleware
{
    public class RequestsRedirector
    {
        private readonly RequestDelegate _next;
        private readonly IRedirectTargetRegistry _redirectTargetRegistry;

        public RequestsRedirector
        (
            RequestDelegate next,
            IRedirectTargetRegistry redirectTargetRegistry
        )
        {
            _next = next;
            _redirectTargetRegistry = redirectTargetRegistry;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var requestSchema = httpContext.Request.Scheme;
            var requestHost = httpContext.Request.Host.Value;
            var requestPath = httpContext.Request.Path.Value;
            var queryString = httpContext.Request.QueryString;

            var destinationAddress = _redirectTargetRegistry
                .FindDestinationRootAddress($"{requestSchema}://{requestHost}");

            if (string.IsNullOrWhiteSpace(destinationAddress))
            {
                httpContext.Response.StatusCode = 404;
                await httpContext.Response.WriteAsync("404 - Resource Not Found.");
            }
            else
            {
                httpContext.Response.Redirect($"{destinationAddress}{requestPath}{queryString}");
                return;
            }
        }
    }
}
