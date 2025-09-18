using Microsoft.EntityFrameworkCore;
using MSCustomer.Application.Repositories;
using MSCustomer.Domain;
using MSCustomer.Infrastructure.Data;

namespace MSCustomer.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var results = await _context.Customers.ToListAsync();
            return results;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with id {id} not found on database.");
            }

            return customer;
        }

        public int Add(Customer customer)
        {
            // Adds a new product to the database
            _context.Customers.Add(customer);

            var result = _context.SaveChanges();

            return result;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
