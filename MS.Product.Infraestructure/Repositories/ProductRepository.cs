using Microsoft.EntityFrameworkCore;
using MSProduct.Application.Repositories;
using MSProduct.Domain;
using MSProduct.Infrastructure.Data;

namespace MSProduct.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var results = await _context.Products.ToListAsync();
            return results;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with id {id} not found on database.");
            }

            return product;
        }

        public int Add(Product product)
        {
            _context.Products.Add(product);
            var result = _context.SaveChanges();

            return result;
        }

        public void Update(int id, Product updatedProduct)
        {
            var product = _context.Products.FirstOrDefault(product => product.Id == id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with id {id} not found on database.");
            }

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Stock = updatedProduct.Stock;

            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(product => product.Id == id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with id {id} not found on database.");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
