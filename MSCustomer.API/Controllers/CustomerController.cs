using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid customer ID.");
            }

            // Get product by id using _productService
            var result = await _customerService.GetCustomerByIdAsync(id);

            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request body is null.");
            }

            // Create product using _productService
            var customerDto = _mapper.Map<CreateCustomerDto>(request);

            var result = _customerService.CreateCustomer(customerDto);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetCustomerById), new { id = result.Value.Id }, request);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] object customerDto)
        {
            // Placeholder for actual implementation
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            // Placeholder for actual implementation
            return NoContent();
        }
    }
}
