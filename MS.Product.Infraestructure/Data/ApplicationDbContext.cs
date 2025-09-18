using Microsoft.EntityFrameworkCore;
using MSProduct.Domain;

namespace MSProduct.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Modificaciones de la base de datos Products

            base.OnModelCreating(modelBuilder);
        }
    }
}
