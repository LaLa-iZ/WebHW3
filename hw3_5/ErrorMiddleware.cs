using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace hw3_5
{
    public class ErrorMiddleware
    {
        private RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
            if (context.Response.StatusCode == 403)
            {
                await context.Response.WriteAsync("Access Denied, authentication needed ");
            }
            else if (context.Response.StatusCode == 404)
            {
                await context.Response.WriteAsync("Not Found, try ../first or ../second");
            }
        }
    }
}