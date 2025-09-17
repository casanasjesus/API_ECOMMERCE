using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSOrder.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }
    }
}
