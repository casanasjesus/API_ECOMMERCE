using Lab.Domain.Entities;
using Lab.Infra.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Gets products from the database
            var products = _dbContext.Products.ToList();
            
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            // Validates the product
            if (product == null)
            {
                return BadRequest("Product is null.");
            }
            // Adds a new product to the database
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product updatedProduct)
        {
            // Validates the updated product
            if (updatedProduct == null || updatedProduct.Id != id)
            {
                return BadRequest("Invalid product data.");
            }
            var existingProduct = _dbContext.Products.Find(id);
            
            if (existingProduct == null)
            {
                return NotFound("Product not found.");
            }
            // Updates the existing product's properties
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.Stock = updatedProduct.Stock;
            
            _dbContext.Products.Update(existingProduct);
            _dbContext.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _dbContext.Products.Find(id);
            
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            // Deletes the product from the database
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            
            return NoContent();
        }
    }
}