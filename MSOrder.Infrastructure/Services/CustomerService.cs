using MSOrder.Application.Dtos;
using MSOrder.Application.Services;
using System.Net.Http.Json;

namespace MSOrder.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7001");
        }

        public async Task<CustomerDto> GetCustomerById(int customerId)
        {
            var response = await _httpClient.GetAsync($"/api/Customer/find-customer/{customerId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var customer = await response.Content.ReadFromJsonAsync<CustomerDto>();

            return customer;
        }
    }
}