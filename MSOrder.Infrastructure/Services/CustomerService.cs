using MSOrder.Application.Dtos;
using MSOrder.Application.Services;
using System.Net.Http.Json;

namespace MSOrder.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        public async Task<CustomerDto> GetCustomerById(int customerId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7001/");

            var response = await httpClient.GetAsync($"/api/Customer/find-customer/{customerId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var customer = await response.Content.ReadFromJsonAsync<CustomerDto>();

            return customer;
        }
    }
}