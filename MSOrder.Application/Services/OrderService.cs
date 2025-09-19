using MSOrder.Application.Dtos;
using MSOrder.Application.Mappers;
using MSOrder.Application.Repositories;
using MSOrder.Domain;

namespace MSOrder.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;

        public OrderService(
            IOrderRepository repository,
            IProductService productService,
            ICustomerService customerService
        )
        {
            _repository = repository;
            _productService = productService;
            _customerService = customerService;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            try
            {
                var orders = await _repository.GetOrders();
                return orders ?? new List<Order>();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving orders.", ex);
            }
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            try
            {
                var order = await _repository.GetOrderById(orderId);

                if (order == null)
                {
                    throw new Exception($"Order with id {orderId} not found on database.");
                }
                    
                return order;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the order.", ex);
            }
        }

        public async Task<Order> CreateOrderAsync(CreateOrderDto request)
        {
            var customerDto = await _customerService.GetCustomerById(request.customerId);

            if (customerDto == null)
            {
                throw new Exception($"Customer with id {request.customerId} not found on database.");
            }

            var customer = new Customer
            {
                Id = customerDto.Id,
                Name = customerDto.Name,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                Address = customerDto.Address,
                DateRegister = customerDto.DateRegister
            };

            var order = new Order
            {
                Customer = customer,
                OrderStatus = OrderStatusMapper.ToDomain(request.status),
                OrderAddress = new Address
                {
                    Street = request.orderAddress.Street,
                    Number = request.orderAddress.Number,
                    City = request.orderAddress.City
                }
            };

            foreach (var item in request.items)
            {
                var product = await _productService.GetProductById(item.ProductId);

                if (product == null)
                {
                    throw new Exception($"Product with id {item.ProductId} not found on database.");
                }
                    
                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    UnitPrice = product.Price,
                    Amount = item.Amount,
                    SubTotal = product.Price * item.Amount
                };

                order.AddOrderItem(orderItem);
            }

            var result = await _repository.Add(order);
            return result;
        }
    }
}
