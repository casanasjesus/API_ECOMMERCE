using System.ComponentModel.DataAnnotations;

namespace MSOrder.Domain
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }

        public DateTime DateRegister { get; set; } = DateTime.UtcNow;
    }
}
