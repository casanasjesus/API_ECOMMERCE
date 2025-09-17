using System.ComponentModel.DataAnnotations;
using Lab.Core;

namespace Lab.Domain.Entities
{
    public class Product : Entity
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(4000)]
        public string? Description { get; set; }
        
        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
