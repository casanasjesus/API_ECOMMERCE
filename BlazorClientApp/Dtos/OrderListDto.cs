using System.Text.Json.Serialization;

namespace BlazorClientApp.Dtos
{
    public class OrderListDto
    {
        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }

        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonPropertyName("orderStatus")]
        public OrderStatusDto OrderStatus { get; set; }

        [JsonPropertyName("orderAddress")]
        public OrderAddressDto OrderAddress { get; set; } = new OrderAddressDto();

        [JsonPropertyName("customer")]
        public CustomerDto Customer { get; set; } = new CustomerDto();

        [JsonPropertyName("orderItems")]
        public List<OrderItemListDto> OrderItems { get; set; } = new List<OrderItemListDto>();

        [JsonPropertyName("totalOrder")]
        public decimal TotalOrder { get; set; }
    }

    public class OrderItemListDto
    {
        [JsonPropertyName("orderItemId")]
        public int OrderItemId { get; set; }

        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }

        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("productName")]
        public string ProductName { get; set; } = string.Empty;

        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("subTotal")]
        public decimal SubTotal { get; set; }
    }
}