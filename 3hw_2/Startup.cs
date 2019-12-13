using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _3hw_2
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            int x = 127;
            int y = 3;
            int z = 0;

            app.Use(async (context, next) =>
            {
                z = ((x * x) + (4 * x)) * ((y + 7) * (y + 7));
                await context.Response.WriteAsync($"y = (x^2 + 4x)(a + 7)^2, ({x}^2 + 4*{x})({y} + 7)^2 = {z} \n");
                y = y * 3;
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                z = ((x * x) + (4 * x)) * ((y + 7) * (y + 7));
                await context.Response.WriteAsync($"y = (x^2 + 4x)(a + 7)^2, ({x}^2 + 4*{x})({y} + 7)^2 = {z} \n");
            });
        }
    }
}
