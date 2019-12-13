using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace hw3_5
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            if (path == "/first")
            {
                int x = 30;
                double angle = Math.PI * x / 180.0;
                double q = Math.Round((Math.Sin(angle / 5) - (Math.Sqrt(3) * x) / 2), 3);

                await context.Response.WriteAsync($"(Sin(x/5) - (sqrt(3a)/2), (Sin({x}/5) - (sqrt(3*{x})/2) = {q} \n");
            }
            else if (path == "/second")
            {
                int x = 27;
                int a = 13;
                double q = Math.Round((Math.Sqrt(Math.Abs(a * a * x - x * x * a)) / 2), 3);

                await context.Response.WriteAsync($"y=(sqrt(|(a^2)x - (x^2)a|)/2, (sqrt(|({a}^2){x} - ({x}^2){a}|)/2 = {q}\n");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
            //await _next.Invoke(context);
        }
    }
}