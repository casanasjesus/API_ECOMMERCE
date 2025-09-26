using BlazorClientApp.Dtos;

namespace BlazorClientApp.Services
{
    public class CustomerApiService : ICustomerApiService
    {
        private readonly HttpClient _http;

        public CustomerApiService(HttpClient http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
        }

        public async Task<HttpResponseMessage> CreateCustomer(CreateCustomerDto customer)
        {
            var response = await _http.PostAsJsonAsync("api/Customer/create-customer", customer);
            return response;
        }

        public async Task<List<CustomerDto>> GetCustomersList()
        {
            var result = await _http.GetFromJsonAsync<List<CustomerDto>>("api/Customer/customers-list");
            return result ?? new List<CustomerDto>();
        }
    }
}
