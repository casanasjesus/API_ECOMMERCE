using MSOrder.Domain;

namespace MSOrder.Application.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        Task<Order> Add(Order order);
    }
}
