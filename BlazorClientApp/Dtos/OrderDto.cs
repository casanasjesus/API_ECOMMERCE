namespace BlazorClientApp.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

        public string? Street { get; set; }

        public string? City { get; set; }

        public int Number { get; set; }

        public int CustomerId { get; set; }

        public string? CustomerName { get; set; }
    }
}
