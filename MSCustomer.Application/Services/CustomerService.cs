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

        public async Task<Result<IEnumerable<Customer>>> GetAllCustomersAsync()
        {
            try
            {
                var customers = await _repository.GetAllAsync();

                if (customers == null)
                {
                    return Result.Fail<IEnumerable<Customer>>("Customers not found");
                }

                return Result.Success(customers);
            }
            catch (Exception ex)
            {
                return Result.Fail<IEnumerable<Customer>>($"An error occurred while retrieving customers: {ex.Message}");
            }
        }

        public async Task<Result<Customer>> GetCustomerByIdAsync(int id)
        {
            try
            {
                var customer = await _repository.GetByIdAsync(id);

                if (customer == null)
                {
                    return Result.Fail<Customer>($"Customer with id {id} not found on database.");
                }

                return Result.Success(customer);
            }
            catch (Exception ex)
            {
                return Result.Fail<Customer>($"An error occurred while retrieving the customer: {ex.Message}");
            }
        }

        public Result<Customer> CreateCustomer(CreateCustomerDto request)
        {
            try
            {
                var customer = new Customer
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    Email = request.Email,
                    Address = request.Address,
                    DateRegister = request.DateRegister,
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
            catch (Exception ex)
            {
                return Result.Fail<Customer>($"An error occurred while creating the customer: {ex.Message}");
            }
        }

        public Result<Customer> UpdateCustomer(int id, UpdateCustomerDto request)
        {
            try
            {
                var existingCustomer = _repository.GetByIdAsync(id).Result;

                if (existingCustomer == null)
                {
                    return Result.Fail<Customer>($"Customer with id {id} not found on database.");
                }

                existingCustomer.Name = request.Name;
                existingCustomer.LastName = request.LastName;
                existingCustomer.Email = request.Email;
                existingCustomer.Address = request.Address;
                existingCustomer.DateRegister = request.DateRegister;

                var validationResult = _validator.Validate(existingCustomer);

                if (!validationResult.IsValid)
                {
                    var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                    return Result.Fail<Customer>(errors);
                }

                _repository.Update(id, existingCustomer);
                return Result.Success(existingCustomer);
            }
            catch (Exception ex)
            {
                return Result.Fail<Customer>($"An error occurred while updating the customer: {ex.Message}");
            }
        }

        public Result DeleteCustomer(int id)
        {
            if (id <= 0)
            {
                return Result.Fail($"Invalid customer id {id}");
            }

            try
            {
                _repository.Delete(id);
                return Result.Success();
            }
            catch (KeyNotFoundException ex)
            {
                return Result.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                return Result.Fail($"An error occurred while deleting the customer: {ex.Message}");
            }
        }
    }
}
