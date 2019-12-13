using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using hw3_7.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace hw3_7
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();

            app.Map("/email", E);
            app.Map("/sms", S);


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page Not Found, try .../email or ../sms");
                
            });

            app.UseHttpsRedirection();
        }

        private void E(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                var messageService = new MessageService(new EmailMessageSender(context));
                await context.Response.WriteAsync(messageService.Send());
            });
        }

        private void S(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                var messageService = new MessageService(new SmsMessageSender(context));
                await context.Response.WriteAsync(messageService.Send());
            });
        }
    }
}
