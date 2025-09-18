using AutoMapper;
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

        public ProductController(IProductService productService, IMapper mapper)
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

            var result = await _productService.GetProductByIdAsync(id);

            if (!result.IsSuccess)
            {
                throw new KeyNotFoundException($"Product with id {id} not found on database.");
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

            var productDto = _mapper.Map<CreateProductDto>(request);

            var result = _productService.CreateProduct(productDto);
            
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetProductById), new { id = result.Value.Id }, request);
        }

        [HttpPut("update-product/{id}")]
        public IActionResult UpdateProductAsync(int id, [FromBody] UpdateProductRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request body is null.");
            }

            if (id <= 0)
            {
                return BadRequest("Invalid product ID.");
            }

            var productDto = _mapper.Map<UpdateProductDto>(request);
            var result = _productService.UpdateProduct(id, productDto);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        [HttpDelete("delete-product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.DeleteProduct(id);

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