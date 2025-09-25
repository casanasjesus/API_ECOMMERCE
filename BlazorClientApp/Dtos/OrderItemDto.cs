using System.ComponentModel.DataAnnotations;

namespace BlazorClientApp.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }

        [StringLength(4000)]
        public string? Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public string? ProductName { get; set; }
    }
}
