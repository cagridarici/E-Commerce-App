using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.RabbitMQ.ConsumerApp
{
    public class MailSenderService
    {
        bool SendRealMail = false;

        public async Task<MailOperationResult> SendMailAsync(MailModel mailModel)
        {
            MailOperationResult operationResult = new MailOperationResult();
            MailMessage mailMessage = CreateMailMessage(mailModel);

            // Uygulamanin Simule Edilebilmesi İcin Mail Gonderilmis Gibi Davrandiriyoruz...
            // İstege Bagli Olarak SMTPConfiguration class'ındaki SMTP bilgileri doldurularak Gercek Mail Gonderimi Saglanabilir...
            if (!SendRealMail)
            {
                operationResult.SuccessMessage = string.Format("{0} Id'li Siparişin Maili Başarıyla Gönderildi !", mailModel.OrderId);
                return operationResult;
            }

            try
            {
                using (var client = CreateSmtpClient())
                {
                    await client.SendMailAsync(mailMessage);
                    operationResult.SuccessMessage = string.Format("{0} Id'li Siparişin Maili Başarıyla Gönderildi !", mailModel.OrderId);
                }
            }
            catch (Exception ex)
            {
                operationResult.SetError(ex);
            }
            finally
            {
                Thread.Sleep(100);
            }
            return operationResult;
        }

        private MailMessage CreateMailMessage(MailModel model)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Subject = model.Subject;
            mailMessage.Body = model.Body;
            mailMessage.From = new MailAddress(model.From);
            mailMessage.To.Add(model.To);
            mailMessage.From = new MailAddress(SMTPConfiguration.User);
            return mailMessage;
        }

        private SmtpClient CreateSmtpClient()
        {
            SmtpClient client = new SmtpClient(SMTPConfiguration.Host, SMTPConfiguration.Port)
            {
                EnableSsl = SMTPConfiguration.UseSSL,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(SMTPConfiguration.User, SMTPConfiguration.Password)
            };
            return client;
        }
    }
}
