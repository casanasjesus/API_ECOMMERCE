using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MSCustomer.API.Dtos;
using MSCustomer.Application.Dtos;
using MSCustomer.Application.Services;

namespace MSCustomer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("customers-list")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _customerService.GetAllCustomersAsync();

            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpGet("find-customer/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid customer ID.");
            }

            var result = await _customerService.GetCustomerByIdAsync(id);

            if (!result.IsSuccess)
            {
                throw new KeyNotFoundException($"Customer with id {id} not found on database.");
            }

            return Ok(result.Value);
        }

        [HttpPost("create-customer")]
        public IActionResult CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request body is null.");
            }

            var customerDto = _mapper.Map<CreateCustomerDto>(request);

            var result = _customerService.CreateCustomer(customerDto);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetCustomerById), new { id = result.Value.Id }, request);
        }

        [HttpPut("update-customer/{id}")]
        public IActionResult UpdateCustomerAsync(int id, [FromBody] UpdateCustomerRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request body is null.");
            }

            if (id <= 0)
            {
                return BadRequest("Invalid customer ID.");
            }

            var customerDto = _mapper.Map<UpdateCustomerDto>(request);
            var result = _customerService.UpdateCustomer(id, customerDto);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpDelete("delete-customer/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var result = _customerService.DeleteCustomer(id);

            if (!result.IsSuccess)
            {
                if (result.Error.Contains("not found", StringComparison.OrdinalIgnoreCase))
                {
                    return NotFound(result.Error);
                }
                return BadRequest(result.Error);
            }

            return NoContent();
        }
    }
}
