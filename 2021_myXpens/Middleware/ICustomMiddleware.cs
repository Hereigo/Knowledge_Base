using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyXpens.Middleware
{
    public interface ICustomMiddleware
    {
        Task InvokeAsync(HttpContext httpContext);
    }
}