namespace BlazorClientApp.Dtos
{
    public class OrderDto
    {
        public int customerId { get; set; }
        public List<OrderItemDto> items { get; set; } = new();
        public OrderStatusDto status { get; set; }
        public OrderAddressDto orderAddress { get; set; } = new();
    }
}
