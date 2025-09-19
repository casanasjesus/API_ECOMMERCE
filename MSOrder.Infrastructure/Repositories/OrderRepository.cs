using Microsoft.EntityFrameworkCore;
using MSOrder.Application.Repositories;
using MSOrder.Domain;
using MSOrder.Infrastructure.Data;

namespace MSOrder.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders
                .Include(order => order.OrderItems)
                .ToListAsync();
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _context.Orders
                .Include(order => order.OrderItems)
                .FirstOrDefaultAsync(order => order.OrderId == orderId);
        }

        public async Task<Order> Add(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
