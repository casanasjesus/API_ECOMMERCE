using Lab.Domain.Entities;

namespace Lab.Application.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        Product GetById(int id);
        
        int Add(Product order);
        
        void Update(int id, Product order);
        
        void Delete(int id);
    }
}
