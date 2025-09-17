using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MSCustomer.Domain
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string? LastName { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        public DateTime DateRegister { get; set; } = DateTime.UtcNow;
    }
}
