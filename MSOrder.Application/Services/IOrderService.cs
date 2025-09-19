using MSOrder.Application.Dtos;
using MSOrder.Domain;

namespace MSOrder.Application.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(CreateOrderDto request);
        Task<List<Order>> GetOrdersAsync();
    }
}
