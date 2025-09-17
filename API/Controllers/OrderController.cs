using Lab.Application.Repositories;
using Lab.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repository;

        public OrderController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Gets orders from the database
            var result = await _repository.GetAllAsync();

            if (!result.IsSuccess)
            {
                return NotFound("No orders found.");
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Order order)
        {
            // Validates the order
            if (order == null)
            {
                return BadRequest("Order is null.");
            }

            // Adds a new order to the database
            var result = _repository.Add(order);

            if (!result.IsSuccess)
            {
                return BadRequest("Could not add the order.");
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Order updatedOrder)
        {
            //// Validates the updated order
            //if (updatedOrder == null || updatedOrder.Id != id)
            //{
            //    return BadRequest("Invalid order data.");
            //}

            //var existingOrder = _dbContext.Orders.Find(id);
            
            //if (existingOrder == null)
            //{
            //    return NotFound("Order not found.");
            //}


            //// Updates the existing order
            //existingOrder.Date = updatedOrder.Date;
            //existingOrder.Total = updatedOrder.Total;
            //existingOrder.ShippingAddress = updatedOrder.ShippingAddress;
            
            //_dbContext.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //var order = _dbContext.Orders.Find(id);
            
            //if (order == null)
            //{
            //    return NotFound("Order not found.");
            //}

            //// Deletes the order from the database
            //_dbContext.Orders.Remove(order);
            //_dbContext.SaveChanges();
            
            return NoContent();
        }
    }
}