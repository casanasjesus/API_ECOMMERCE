using BlazorClientApp.Dtos;

namespace BlazorClientApp.Services
{
    public interface IOrderApiService
    {
        Task<HttpResponseMessage> SaveOrderAsync(OrderDto order);
    }
}