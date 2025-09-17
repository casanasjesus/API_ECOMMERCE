using System.ComponentModel.DataAnnotations;
using Lab.Core;

namespace Lab.Domain.Entities
{
    public class OrderItem : Entity
    {
        [StringLength(4000)]
        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
