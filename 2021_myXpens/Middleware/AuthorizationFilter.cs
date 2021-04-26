using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace MyXpens.Middleware
{
    public class AuthorizationFilter : ICustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppStaticValues _appStaticValues;

        public AuthorizationFilter(RequestDelegate next, IOptions<AppStaticValues> stat)
        {
            _appStaticValues = stat.Value;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var currentUserEmail = httpContext.User.FindFirst(ClaimTypes.Name);

            if(currentUserEmail?.Value?.Equals(_appStaticValues.DefaultEmail, StringComparison.OrdinalIgnoreCase) == false)
            {
                await httpContext.Response.WriteAsync("500 Internal Server Error");
            }
            else
            {
                await _next.Invoke(httpContext);
            }
        }
    }
}
