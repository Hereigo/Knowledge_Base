using Microsoft.AspNetCore.Builder;

namespace RedirectMiddleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestsRedirector(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestsRedirector>();
        }
    }
}
