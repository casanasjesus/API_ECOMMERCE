namespace Lab.Domain.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

        public string Street { get; set; }

        public string City { get; set; }

        public int Number { get; set; }
    }

    public class OrderItemDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
