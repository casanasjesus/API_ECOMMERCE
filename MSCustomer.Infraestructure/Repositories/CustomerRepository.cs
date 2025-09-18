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
            _context.Customers.Add(customer);
            var result = _context.SaveChanges();

            return result;
        }

        public void Update(int id, Customer updatedCustomer)
        {
            var customer = _context.Customers.FirstOrDefault(customer => customer.Id == id);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with id {id} not found on database.");
            }

            customer.Name = updatedCustomer.Name;
            customer.LastName = updatedCustomer.LastName;
            customer.Email = updatedCustomer.Email;
            customer.Address = updatedCustomer.Address;
            customer.DateRegister = updatedCustomer.DateRegister;

            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(customer => customer.Id == id);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with id {id} not found on database.");
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
