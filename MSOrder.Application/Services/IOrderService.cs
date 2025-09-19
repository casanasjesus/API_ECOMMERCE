using MSOrder.Domain;

namespace MSOrder.Application.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order, int customerId, int productId);
    }
}
