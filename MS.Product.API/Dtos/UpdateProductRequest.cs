namespace MSProduct.API.Dtos
{
    public record UpdateProductRequest(string? Description, decimal Price, int Stock);
}
