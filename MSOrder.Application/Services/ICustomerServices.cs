using MSOrder.Application.Dtos;

namespace MSOrder.Application.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerById(int customerId);
    }
}