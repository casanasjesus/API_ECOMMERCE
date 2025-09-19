using MSOrder.Application.Dtos;
using MSOrder.Application.Services;
using System.Net.Http.Json;

namespace MSOrder.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:6001/");
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var response = await _httpClient.GetAsync($"/api/Product/find-product/{productId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var product = await response.Content.ReadFromJsonAsync<ProductDto>();

            return product;
        }

        public async Task<bool> UpdateProductStockAsync(int productId, int newStock)
        {
            var product = await GetProductById(productId);

            if (product == null)
            {
                return false;
            }

            var updateRequest = new UpdateProductDto(
                product.Name,
                product.Description,
                product.Price,
                newStock
            );

            var response = await _httpClient.PutAsJsonAsync($"/api/Product/update-product/{productId}", updateRequest);

            return response.IsSuccessStatusCode;
        }
    }
}
