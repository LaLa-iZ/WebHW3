using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace hw3_7.Services
{
    public class SmsMessageSender : IMessageSender
    {
        private string mes;
        public SmsMessageSender(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey("text"))
            {
                mes = context.Request.Cookies["text"];
            }
            else
            {
                context.Response.Cookies.Append("text", "Now there are some cookies");
            }

        }

        public string Send()
        {
            return mes == null ? "Text is empty" : mes;
        }
            
    }
}
