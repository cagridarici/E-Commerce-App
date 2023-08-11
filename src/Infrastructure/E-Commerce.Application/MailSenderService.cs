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
    /// RabbitMQ Operasyonlarini Yurutecek Mail Servisi...
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
