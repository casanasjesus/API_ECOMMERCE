using Lab.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Fields
        private string _maxLength = "100";

        // Constructors
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Properties
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        // Methods
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuraciones avanzadas
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(int.Parse(_maxLength));
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Total)
                      .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.UnitPrice)
                      .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price)
                      .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Order>().OwnsOne(o => o.ShippingAddress);

            modelBuilder.Entity<Customer>().OwnsOne(o => o.Address);

            base.OnModelCreating(modelBuilder);
        }
    }
}
