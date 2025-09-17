using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Task<Customer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
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
