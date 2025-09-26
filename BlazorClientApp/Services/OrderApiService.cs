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

        public async Task<HttpResponseMessage> CreateOrder(OrderDto order)
        {
            var response = await _http.PostAsJsonAsync("api/Order/create-order", order);
            return response;
        }

        public async Task<List<OrderListDto>> GetOrdersList()
        {
            var result = await _http.GetFromJsonAsync<List<OrderListDto>>("api/Order/get-orders");
            return result ?? new List<OrderListDto>();
        }
    }
}