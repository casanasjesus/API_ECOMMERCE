using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return product;
        }

        public int Add(Product product)
        {
            _context.Products.Add(product);
            var result = _context.SaveChanges();

            return result;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Product order)
        {
            throw new NotImplementedException();
        }
    }
}
