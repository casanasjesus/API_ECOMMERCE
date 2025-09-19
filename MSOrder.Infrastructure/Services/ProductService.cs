using MSOrder.Application.Dtos;
using MSOrder.Application.Services;
using System.Net.Http.Json;

namespace MSOrder.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        public async Task<ProductDto> GetProductById(int productId)
        {
            HttpClient httpClient  = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:6001/");

            var response = await httpClient.GetAsync($"/api/Product/find-product/{1}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var product = await response.Content.ReadFromJsonAsync<ProductDto>();

            return product;
        }
    }
}
