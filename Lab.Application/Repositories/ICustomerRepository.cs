using Lab.Domain.Entities;

namespace Lab.Application.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Customer GetById(int id);

        int Add(Customer order);

        void Update(int id, Customer order);

        void Delete(int id);
    }
}
