using MSOrder.Application.Dtos;
using MSOrder.Domain;

namespace MSOrder.Application.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<Order> CreateOrderAsync(CreateOrderDto request);
    }
}
