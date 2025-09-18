using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSProduct.Application.Dtos;
using MSProduct.Application.Repositories;
using MSProduct.Application.Validators;
using MSProduct.Domain;

namespace MSProduct.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ProductValidator _validator;

        public ProductService(IProductRepository repository, ProductValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Result<IEnumerable<Product>>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllAsync();

            if (products == null)
            {
                return Result.Fail<IEnumerable<Product>>("Products not found");
            }

            return Result.Success(products);
        }

        public async Task<Result<Product>> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                return Result.Fail<Product>("Product not found");
            }

            return Result.Success(product);
        }

        public Result<Product> CreateProduct(CreateProductDto request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock
            };

            var validationResult = _validator.Validate(product);

            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return Result.Fail<Product>(errors);
            }

            var id = _repository.Add(product);
            product.Id = id;

            return Result.Success(product);
        }

        public Result<Product> UpdateProduct(int id, UpdateProductDto request)
        {
            var existingProduct = _repository.GetByIdAsync(id).Result;

            if (existingProduct == null)
            {
                return Result.Fail<Product>($"Product with id {id} not found on database.");
            }

            existingProduct.Name = request.Name;
            existingProduct.Description = request.Description;
            existingProduct.Price = request.Price;
            existingProduct.Stock = request.Stock;

            var validationResult = _validator.Validate(existingProduct);

            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return Result.Fail<Product>(errors);
            }

            _repository.Update(id, existingProduct);
            return Result.Success(existingProduct);
        }

        public Result DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
