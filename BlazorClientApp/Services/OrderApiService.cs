using BlazorClientApp.Dtos;

namespace BlazorClientApp.Services
{
    public class OrderApiService : IOrderApiService
    {
        private readonly HttpClient _http;

        public OrderApiService(HttpClient http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
        }

        public async Task<HttpResponseMessage> SaveOrderAsync(OrderDto order)
        {
            var response = await _http.PostAsJsonAsync("api/order", order);
            return response;
        }
    }
}