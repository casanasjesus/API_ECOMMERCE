using BlazorClientApp.Dtos;

namespace BlazorClientApp.Services
{
    public interface IOrderApiService
    {
        Task<HttpResponseMessage> CreateOrder(OrderDto order);
        Task<List<OrderListDto>> GetOrdersList();
    }
}