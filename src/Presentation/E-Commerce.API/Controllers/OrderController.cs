using E_Commerce.Application;
using E_Commerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderAppService _OrderAppService;
        private InvoiceAppService _InvoiceAppService;
        private MailSenderService _MailSenderService;

        public OrderController(
            InvoiceAppService invoiceAppService,
            OrderAppService orderAppService,
            MailSenderService mailSenderService)
        {
            _OrderAppService = orderAppService;
            _InvoiceAppService = invoiceAppService;
            _MailSenderService = mailSenderService;
        }

        /// <summary>
        /// Siparis Olusturma Mail Gonderim İslemlerinin Buradaki Fatura Hazirlama vs. Surecleri Etkilememesi icin Yani Asenkron Calismasi İcin
        /// Queue Yapisi Olarak RabbitMQ Kullanildi RabbitMQ bir background service olarak Mail Gonderme İslerini Kendisi Yürütmektedir...
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            List<string> errors = CheckDtoValues(orderDto);
            if (errors.Count != 0)
            {
               return BadRequest(errors);
            }

            // Map araci kullanmadim o nedenle entity objelerini manuel olusturuyorum...
            Order order = new Order()
            {
                CustomerId = orderDto.CustomerId,
                Amount = orderDto.Amount,
                ProductId = orderDto.ProductId,
                OrderStatus = (short)OrderStatus.Pending
            };

            // Operasyonun basarili olup olmadigini check etmek icin OperationResult tipinde geri donus alip IsSuccess durumuna bakiyorum.
            // IsSuccess false ise dogrudan hata (400)BadRequest olarak mesajini kullaniciya donduruyoruz...
            OperationResult result = await _OrderAppService.InsertItem(order);
            if (result.IsSuccess)
            {
                // E-Mail Gonderimi İcin Eklenen Orderın İlişkili Property'lerini Set ediyoruz...
                OperationResult<Order> operationResult = await _OrderAppService.GetOrderWithIncludes(order.Id);
                Order insertedOrder = operationResult.Value;

                // Mail İşlemleri Komple RabbitMQ tarafından asenkron bir sekilde yürütülmektedir...
                MailModel mailModel = new MailModel();

                mailModel.OrderId = insertedOrder.Id;
                mailModel.To = insertedOrder.Customer.EmailAddress;
                mailModel.Subject = "Siparişiniz Başarıyla Oluşturuldu !";
                mailModel.Body = string.Format(@"
                    Sipariş Detayları : 
                    Ürün Adı : {0}
                    Adet : {1}
                    Birim Fiyat : {2}
                ", insertedOrder.Product.ProductName
                 , insertedOrder.Amount
                 , insertedOrder.Product.UnitPriceString);



                // Mail nesnesini Servis Metodu aracılığıyla RabbitMQ'ya iletiyoruz...
                // Sonrasinda Consumerda Alip Mail Gonderme İslemlerini Gerceklestiriyoruz...
                _MailSenderService.SendMailToQueue(mailModel);


                // Fatura Olusturuluyor... 
                // (Senaryo Geregi Burdaki İslem Uzun Sürmektedir.) 
                // Mail Gonderme İslerini RabbitMQ yerine burada Yaptırsaydık 8000 request aynı anda icin ciddi performans sorunu olabilirdi...
                Invoice invoice = new Invoice()
                {
                    OrderId = order.Id,
                    InvoiceNumber = Guid.NewGuid(),
                    InvoiceDateUtc = DateTime.UtcNow
                };

                await _InvoiceAppService.InsertItem(invoice);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }

            // Siparis basariyla olusturuldu...
            return Ok(order);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public List<string> CheckDtoValues(OrderDto orderDto)
        {
            /* Check Dto Property Values */
            string zeroErrorMessage = "{0} Degeri 0 Olamaz! 1 Kullanabilirsiniz... Db'de ekli olması lazım";

            List<string> errors = new List<string>();

            if (orderDto.CustomerId == 0)
            {
                errors.Add(string.Format(zeroErrorMessage, "customer_id"));
            }
            if (orderDto.Amount == 0)
            {
                errors.Add(string.Format(zeroErrorMessage, "amount"));
            }
            if (orderDto.ProductId == 0)
            {
                errors.Add(string.Format(zeroErrorMessage, "product_id"));
            }
            return errors;
        }
    }
}
