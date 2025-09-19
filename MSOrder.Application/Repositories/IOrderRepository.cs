using MSOrder.Domain;

namespace MSOrder.Application.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrderById(int orderId);
        Task<Order> Add(Order order);
    }
}
