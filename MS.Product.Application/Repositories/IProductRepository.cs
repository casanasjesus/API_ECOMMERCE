using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSProduct.Domain;

namespace MSProduct.Application.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        int Add(Product order);

        void Update(int id, Product order);

        void Delete(int id);
    }
}
