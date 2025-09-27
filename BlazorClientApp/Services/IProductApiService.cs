using BlazorClientApp.Dtos;

namespace BlazorClientApp.Services
{
    public interface IProductApiService
    {
        Task<HttpResponseMessage> CreateProduct(CreateProductDto product);
        Task<List<ProductDto>> GetProductsList();
        Task<HttpResponseMessage> DeleteProduct(int id);
    }
}
