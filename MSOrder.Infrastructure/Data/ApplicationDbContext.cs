using Microsoft.EntityFrameworkCore;
using MSOrder.Domain;

namespace MSOrder.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Modificaciones de la base de datos Products

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .OwnsOne(o => o.OrderAddress);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<Order>().OwnsOne(o => o.Customer);
        }
    }
}
