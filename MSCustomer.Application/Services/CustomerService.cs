using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSCustomer.Application.Dtos;
using MSCustomer.Application.Repositories;
using MSCustomer.Application.Validators;
using MSCustomer.Domain;

namespace MSCustomer.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerValidator _validator;

        public CustomerService(ICustomerRepository repository, CustomerValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Result<Customer>> GetCustomerByIdAsync(int id)
        {
            var customer = await _repository.GetByIdAsync(id);

            if (customer == null)
            {
                return Result.Fail<Customer>("Customer not found");
            }

            return Result.Success(customer);
        }

        public Task<Result<IEnumerable<Customer>>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Result<Customer> CreateCustomer(CreateCustomerDto request)
        {
            var customer = new Customer
            {
                Name = request.Name,
                LastName = request.LastName,
            };

            var validationResult = _validator.Validate(customer);

            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return Result.Fail<Customer>(errors);
            }

            var id = _repository.Add(customer);
            customer.Id = id;

            return Result.Success(customer);
        }

        public Result<Customer> UpdateCustomer(int id, UpdateCustomerDto request)
        {
            throw new NotImplementedException();
        }

        public Result DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
