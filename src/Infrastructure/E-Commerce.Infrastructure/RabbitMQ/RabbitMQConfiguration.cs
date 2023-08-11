using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.RabbitMQ
{
    public class RabbitMQConfiguration
    {
        public const string HostName = "localhost";
        public const string UserName = "guest";
        public const string Password = "guest";
        public const string EmailSendingQueueName = "E-Mail";
    }
}
