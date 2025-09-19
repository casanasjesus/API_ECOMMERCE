namespace MSOrder.Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public decimal Price { get; init; }
        public int Stock { get; set; }
    }
}
