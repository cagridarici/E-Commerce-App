using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.RabbitMQ.ConsumerApp
{
    public class SMTPConfiguration
    {
        public const string Host = "smtp.gmail.com";
        public const int    Port = 465;
        public const string User = "emailservisi892@gmail.com";
        public const string Password = "!g!uSM4f46g8RW*K";
        public const bool   UseSSL = true;
    }
}
