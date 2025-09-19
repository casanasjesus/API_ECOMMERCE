using Microsoft.AspNetCore.Mvc;
using MSOrder.Application.Services;
using MSOrder.Domain;

namespace MSOrder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create-order")]
        public IActionResult Post([FromBody] Order order, int customerId, int productId)
        {
            var result = _orderService.CreateOrderAsync(order, customerId, productId);

            return Ok("Order created");
        }
    }
}
