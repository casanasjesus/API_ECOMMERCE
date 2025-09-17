


namespace Lab.Infra.UoWs
{
    public class OrderUoW : IOrderUow
    {
        private readonly ApplicationDbContext _dbContext;
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;

        public OrderUoW(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            _orderRepository = new OrderRepository(_dbContext);
            _productRepository = new ProductRepository(_dbContext);
        }

        public int CreateNewOrderWithCustomer(Order order, Customer customer)
        {
            // TODO: logica entre order y customer
            throw new NotImplementedException();
        }
    }
}