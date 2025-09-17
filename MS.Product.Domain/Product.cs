using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProduct.Domain
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(4000)]
        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
