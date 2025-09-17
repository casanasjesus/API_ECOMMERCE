using System.ComponentModel.DataAnnotations;
using Lab.Core;
using Lab.Domain.ValueObjects;

namespace Lab.Domain.Entities
{
    public class Customer : Entity
    {
        [StringLength(8)]
        public string Dni { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        public Address Address { get; set; }
    }
}
