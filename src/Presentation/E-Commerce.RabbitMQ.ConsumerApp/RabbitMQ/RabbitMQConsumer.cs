using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Infrastructure.RabbitMQ;
using RabbitMQ.Client.Exceptions;
using System.Net.Mail;

namespace E_Commerce.RabbitMQ.ConsumerApp.RabbitMQ
{
    public class RabbitMQConsumer
    {
        /// <summary>
        /// RabbitMQ'dan Queue'lar alındıkca Console'a Mesaj Yazdirmak İcin Bu Eventi Kullaniyorum
        /// </summary>
        public event EventHandler<MailModel> MessageReceived;

        /// <summary>
        /// Mail Objesi SMTP'ye İletildiginde Bu Eventi Tetikliyorum Bu Sayede İslem Sonucu Konsola Yazdırıyorum.
        /// </summary>
        public event EventHandler<MailOperationResult> MailSended;

        private EventingBasicConsumer _Consumer;
        private IModel _Channel;
        private IConnection _RabbitMQConnection;
        MailSenderService _MailSenderService;
        public RabbitMQConsumer()
        {
            _MailSenderService = new MailSenderService();
        }

        public void Start()
        {
            try
            {
                if (_RabbitMQConnection == null)
                    _RabbitMQConnection = GetConnection();
                _Channel = _RabbitMQConnection.CreateModel();
                _Channel.QueueDeclare(queue: RabbitMQConfiguration.EmailSendingQueueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                // Performans icin Paralel calisacak threadi 3 belirttim.
                _Channel.BasicQos(0, 3, false);
                _Consumer = new EventingBasicConsumer(_Channel);
                _Consumer.Received += Consumer_Received;

                _Channel.BasicConsume(queue: RabbitMQConfiguration.EmailSendingQueueName,
                                           autoAck: false,
                                           consumer: _Consumer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message.ToString());
            }
        }

        private async void Consumer_Received(object sender, BasicDeliverEventArgs eventArgs)
        {

            MailModel mailModel = ObjectConverter.JsonToObject<MailModel>(Encoding.UTF8.GetString(eventArgs.Body.ToArray()));
            MessageReceived.Invoke(this, mailModel);

            MailOperationResult result = await _MailSenderService.SendMailAsync(mailModel);

            MailSended.Invoke(this, result);
            _Channel.BasicAck(eventArgs.DeliveryTag, false);
        }

        public void Stop()
        {
            Dispose();
        }

        public void Dispose()
        {
            _Channel.Dispose();
            _RabbitMQConnection.Dispose();
        }

        public IConnection GetConnection()
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = RabbitMQConfiguration.HostName,
                    UserName = RabbitMQConfiguration.UserName,
                    Password = RabbitMQConfiguration.Password
                };

                factory.AutomaticRecoveryEnabled = true;
                factory.NetworkRecoveryInterval = TimeSpan.FromSeconds(10);

                return factory.CreateConnection();
            }
            catch (BrokerUnreachableException)
            {
                // Consumer kapsamında Log islemleri vs.
                Thread.Sleep(10000);
                return GetConnection();
            }
        }
    }

}
