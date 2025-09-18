namespace MSProduct.API.Dtos
{
    public record UpdateProductRequest(string Name, string? Description, decimal Price, int Stock);
}
