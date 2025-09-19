using MSOrder.Application.Repositories;
using MSOrder.Domain;

namespace MSOrder.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task<Order> Add(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
