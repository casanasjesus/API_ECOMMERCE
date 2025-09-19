using MSProduct.Application.Dtos;
using MSProduct.Domain;

namespace MSProduct.Application.Services
{
    public interface IProductService
    {
        Task<Result<IEnumerable<Product>>> GetAllProductsAsync();
        Task<Result<Product>> GetProductByIdAsync(int id);
        Result<Product> CreateProduct(CreateProductDto request);
        Result<Product> UpdateProduct(int id, UpdateProductDto request);
        Result DeleteProduct(int id);
    }
}
