using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSCustomer.Domain;

namespace MSCustomer.Application.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();

        Task<Customer> GetByIdAsync(int id);

        int Add(Customer customer);

        void Update(int id, Customer customer);

        void Delete(int id);
    }
}
