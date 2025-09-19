using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MSOrder.API.Dtos;
using MSOrder.Application.Dtos;
using MSOrder.Application.Services;

namespace MSOrder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("get-orders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync();

            if (orders == null)
            {
                return BadRequest("Request body is null.");
            }

            return Ok(orders);
        }

        [HttpGet("get-order/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);

                if (order == null)
                {
                    return NotFound($"Order with id {id} not found on database.");
                }
                    
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> Post([FromBody] CreateOrderRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request body is null.");
            }

            var orderDto = _mapper.Map<CreateOrderDto>(request);

            var result = await _orderService.CreateOrderAsync(orderDto);
            return Ok(result);
        }
    }
}
