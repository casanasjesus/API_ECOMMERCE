
namespace Lab.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<List<OrderDto>>> GetAllAsync()
        {
            // Gets orders from the database
            var orders = await _dbContext.Orders
                                   .Include(o => o.OrderItems)
                                   .ToListAsync();

            List<OrderDto> orderDtos = new List<OrderDto>();

            // implement mapping from Order to OrderDto if needed
            foreach (var order in orders) {
                orderDtos.Add(new OrderDto
                {
                    Id = order.Id,
                    Date = order.Date,
                    Total = order.Total,
                    Street = order.ShippingAddress.Street,
                    City = order.ShippingAddress.City,
                    Number =order.ShippingAddress.Number,
                    OrderItems = order.OrderItems.Select(oi => new OrderItemDto 
                    {
                        Id = oi.Id,
                        UnitPrice = oi.UnitPrice,
                        Quantity = oi.Quantity
                    }).ToList()
                });
            }

            return Result<List<OrderDto>>.Success(orderDtos);
        }

        public Task<Result<Order>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Result Add(Order order)
        {
            // Validates the order
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order is null.");
            }

            // Adds a new order to the database
            _dbContext.Orders.Add(order);
            int result = _dbContext.SaveChanges();

            return Result.Success();
        }

        public Result Update(int id, Order order)
        {
            throw new NotImplementedException();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
