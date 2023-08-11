using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.RabbitMQ
{
    /// <summary>
    /// RabbitMQ Producer İslerini Yürütecek Class...
    /// </summary>
    public class RabbitMQMailSenderService : IDisposable
    {
        IConnection _RabbitMQConnection;
        IModel _Channel;

        public void SendQueue<T>(T obj) where T : class, new()
        {
            try
            {
                if (_RabbitMQConnection == null)
                    _RabbitMQConnection = GetConnection();

                using (_Channel = _RabbitMQConnection.CreateModel())
                {
                    _Channel.QueueDeclare(queue: RabbitMQConfiguration.EmailSendingQueueName,
                                         durable: true,      
                                         exclusive: false,   
                                         autoDelete: false,  
                                         arguments: null);   

                    var properties = _Channel.CreateBasicProperties();
                    properties.Persistent = true;

                    var body = Encoding.UTF8.GetBytes(ObjectConverter.ObjectToJson(obj));
                    _Channel.BasicPublish(exchange: "",
                                         routingKey: RabbitMQConfiguration.EmailSendingQueueName,
                                         mandatory: false,
                                         basicProperties: properties,
                                         body: body);
                }

            }
            catch (Exception)
            {
                // Log islemleri vs.
            }
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
                // Producer kapsamında Log islemleri vs.
                Thread.Sleep(10000);
                return GetConnection();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            GC.SuppressFinalize(this);
        }
    }
}
