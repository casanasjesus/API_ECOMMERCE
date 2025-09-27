using BlazorClientApp.Dtos;

namespace BlazorClientApp.Services
{
    public interface ICustomerApiService
    {
        Task<HttpResponseMessage> CreateCustomer(CreateCustomerDto customer);
        Task<List<CustomerDto>> GetCustomersList();
        Task<HttpResponseMessage> DeleteCustomer(int id);
    }
}
