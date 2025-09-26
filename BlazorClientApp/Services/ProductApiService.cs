using BlazorClientApp.Dtos;

namespace BlazorClientApp.Services
{
    public class ProductApiService : IProductApiService
    {
        private readonly HttpClient _http;

        public ProductApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<HttpResponseMessage> CreateProduct(CreateProductDto product)
        {
            var response = await _http.PostAsJsonAsync("api/Product/create-product", product);
            return response;
        }

        public async Task<List<ProductDto>> GetProductsList()
        {
            var result = await _http.GetFromJsonAsync<List<ProductDto>>("api/Product/products-list");
            return result ?? new List<ProductDto>();
        }
    }
}
