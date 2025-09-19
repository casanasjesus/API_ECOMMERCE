using MSOrder.Application.Repositories;
using MSOrder.Domain;

namespace MSOrder.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IProductService _productService;

        public OrderService(IOrderRepository repository, IProductService productService)
        {
            _repository = repository;
            _productService = productService;
        }

        public async Task<Order> CreateOrderAsync(Order order, int customerId, int productId)
        {
            var product = await _productService.GetProductById(productId);

            var orderItem = new OrderItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                UnitPrice = product.Price,
                Amount = 1
            };

            order.AddOrderItem(orderItem);

            var result = await _repository.Add(order);

            return result;
        }
    }
}
