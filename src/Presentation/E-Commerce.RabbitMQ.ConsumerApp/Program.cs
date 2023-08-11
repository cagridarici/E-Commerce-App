using System.Data.Common;
using System.Text;
using System.Threading.Channels;
using System.Threading;
using E_Commerce.RabbitMQ.ConsumerApp.RabbitMQ;
using E_Commerce.RabbitMQ.ConsumerApp;

Console.WriteLine("RabbitMQ.ConsumerConsole Uygulamasi Baslatildi RabbitMQ'daki Tum Queue'lar İslenerek Mail Atilacaktir...");
Console.WriteLine("");

RabbitMQConsumer consumer = new RabbitMQConsumer();
consumer.MessageReceived += Consumer_MessageReceived;
consumer.MailSended += Consumer_MailSended;


consumer.Start();


void Consumer_MessageReceived(object sender, MailModel e)
{
    Console.WriteLine(string.Format("RabbitMQ'dan {0}'Idli Siparisin Mail Bilgisi Alindi Mail Gonderme İslemi Yapiliyor...", e.OrderId));
    Console.WriteLine(string.Format("Alinan Mail Bilgileri => Gonderilecek Adres : {0} ", e.To));
    Console.WriteLine(string.Format("Mail İçeriği : {0}", e.Body));
    Console.WriteLine("");
}

void Consumer_MailSended(object sender, MailOperationResult e)
{
    // Mail Basariyla İletildiyse
    if (e.IsSuccess)
    {
        Console.WriteLine(e.SuccessMessage);
        Console.WriteLine("");
    }
    else
    {
        Console.WriteLine("Mail Gonderilemedi Bir Hata Olustu :" + e.ErrorMessage);
        Console.WriteLine("");
    }
}


Console.ReadKey();