using BlazorClientApp.Dtos;

namespace BlazorClientApp.Services
{
    public interface ICustomerApiService
    {
        Task<HttpResponseMessage> CreateCustomer(CreateCustomerRequest customer);
    }
}
