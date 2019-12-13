using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace _3hw_4
{

    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token != "1")
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid, try ../?token=1");
            }
            else
            {
                int x = 30;
                double angle = Math.PI * x / 180.0;
                double q = Math.Round((Math.Sin(angle) * Math.Cos(angle) * Math.Cos(2 * angle)), 3);
                await context.Response.WriteAsync($"y=Sin(x)Cos(x)Cos(2x), Sin({x})Cos({x})Cos(2*{x}) = {q}\n");
                await _next.Invoke(context);
            }
        }
    }
}