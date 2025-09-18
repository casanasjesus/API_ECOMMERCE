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
            try
            {
                var products = await _repository.GetAllAsync();

                if (products == null)
                {
                    return Result.Fail<IEnumerable<Product>>("Products not found");
                }

                return Result.Success(products);
            }
            catch (Exception ex)
            {
                return Result.Fail<IEnumerable<Product>>($"An error occurred while retrieving products: {ex.Message}");
            }
        }

        public async Task<Result<Product>> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _repository.GetByIdAsync(id);

                if (product == null)
                {
                    return Result.Fail<Product>($"Product with id {id} not found on database.");
                }

                return Result.Success(product);
            }
            catch (Exception ex)
            {
                return Result.Fail<Product>($"An error occurred while retrieving the product: {ex.Message}");
            }
        }

        public Result<Product> CreateProduct(CreateProductDto request)
        {
            try
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
            catch (Exception ex)
            {
                return Result.Fail<Product>($"An error occurred while creating the product: {ex.Message}");
            }
        }

        public Result<Product> UpdateProduct(int id, UpdateProductDto request)
        {
            try
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
            catch (Exception ex)
            {
                return Result.Fail<Product>($"An error occurred while updating the product: {ex.Message}");
            }
        }

        public Result DeleteProduct(int id)
        {
            if (id <= 0)
            {
                return Result.Fail($"Invalid product id {id}");
            }

            try
            {
                _repository.Delete(id);
                return Result.Success();
            }
            catch (KeyNotFoundException ex)
            {
                return Result.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                return Result.Fail($"An error occurred while deleting the product: {ex.Message}");
            }
        }
    }
}
