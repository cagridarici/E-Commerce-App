using System.Text.Json.Serialization;

namespace E_Commerce.API
{
    public class OrderDto
    {
        [JsonPropertyName("customer_id")]
        public int CustomerId { get; set; }

        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get;set; }
    }
}
