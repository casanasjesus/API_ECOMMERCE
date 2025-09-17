using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSCustomer.Application.Dtos;
using MSCustomer.Domain;

namespace MSCustomer.Application.Services
{
    public interface ICustomerService
    {
        Task<Result<Customer>> GetCustomerByIdAsync(int id);
        Task<Result<IEnumerable<Customer>>> GetAllCustomersAsync();
        Result<Customer> CreateCustomer(CreateCustomerDto request);
        Result<Customer> UpdateCustomer(int id, UpdateCustomerDto request);
        Result DeleteCustomer(int id);
    }
}
