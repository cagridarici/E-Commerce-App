using E_Commerce.Infrastructure.RabbitMQ;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace E_Commerce.Application
{
    /// <summary>
    /// RabbitMQ Servisiyle İletisime Gecerek Mail İslemlerini Gerceklestirecek Class
    /// </summary>
    public class MailSenderService : IApplicationService
    {
        RabbitMQMailSenderService _RabbitMQMailSenderService;

        public MailSenderService(RabbitMQMailSenderService mailSenderService)
        {
            _RabbitMQMailSenderService = mailSenderService;
        }

        public void SendMailToQueue(MailModel mailModel)
        {
            _RabbitMQMailSenderService.SendQueue(mailModel);
        }
    }
}
