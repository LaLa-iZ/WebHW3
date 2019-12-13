using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hw3_7.Services;

namespace hw3_7
{
    public class MessageService
    {
        IMessageSender _sender;
        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }
        public string Send()
        {
            return _sender.Send();
        }
    }
}
