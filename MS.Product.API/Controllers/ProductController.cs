using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSProduct.API.Dtos;
using MSProduct.Application.Dtos;
using MSProduct.Application.Services;

namespace MSProduct.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(
            IProductService productService, 
            IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("products-list")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _productService.GetAllProductsAsync();

            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }
        
        [HttpGet("find-product/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid product ID.");
            }

            // Get product by id using _productService
            var result = await _productService.GetProductByIdAsync(id);

            if (!result.IsSuccess)
            {
                return NotFound();
            }

            return Ok(result.Value);
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody] CreateProductRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request body is null.");
            }

            // Create product using _productService
            var productDto = _mapper.Map<CreateProductDto>(request);

            var result = _productService.CreateProduct(productDto);
            
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetProductById), new { id = result.Value.Id }, request);
        }

        [HttpPut("update-product/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] object productDto)
        {
            // Placeholder for actual implementation
            return NoContent();
        }

        [HttpDelete("delete-product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            // Placeholder for actual implementation
            return NoContent();
        }
    }
}