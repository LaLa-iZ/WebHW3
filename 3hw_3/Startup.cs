using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _3hw_3
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Map("/first", F);
            app.Map("/second", S);
            

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page Not Found, try .../first or ../second");
            });
        }

        private static void F(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                int x = 30;
                double angle = Math.PI * x / 180.0;
                double q = Math.Round((Math.Sin(angle / 5) - (Math.Sqrt(3) * x) / 2), 3);

                await context.Response.WriteAsync($"(Sin(x/5) - (sqrt(3a)/2), (Sin({x}/5) - (sqrt(3*{x})/2) = {q} \n");
            });
        }
        private static void S(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                int x = 27;
                int a = 13;
                double q = Math.Round((Math.Sqrt(Math.Abs(a * a * x - x * x * a)) / 2), 3);

                await context.Response.WriteAsync($"y=(sqrt(|(a^2)x - (x^2)a|)/2, (sqrt(|({a}^2){x} - ({x}^2){a}|)/2 = {q}\n");
            });
        }
    }
}
