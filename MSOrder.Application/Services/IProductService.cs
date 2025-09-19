using MSOrder.Application.Dtos;

namespace MSOrder.Application.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProductById(int productId);
    }
}
