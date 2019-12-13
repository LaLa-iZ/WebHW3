using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw3_7.Services
{
    public class EmailMessageSender : IMessageSender
    {
        private string mes;
        public EmailMessageSender(HttpContext context)
        {
            if (context.Session.Keys.Contains("txt"))
            {
                mes = context.Session.GetString("txt");
            }
            else
            {
                context.Session.SetString("txt", "Smth about new session");
            }
        }

        public string Send()
        {
            return mes== null ? "Text is empty" : mes;
        }
    }
}
