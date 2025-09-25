using BlazorClientApp.Dtos;

namespace BlazorClientApp.Services
{
    public class CustomerApiService : ICustomerApiService
    {
        private readonly HttpClient _http;

        public CustomerApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> CreateCustomer(CreateCustomerRequest customer)
        {
            var response = await _http.PostAsJsonAsync("api/Customer/create-customer", customer);
            return response;
        }
    }
}
