namespace MSProduct.Application.Dtos
{
    public record UpdateProductDto(string Name, string? Description, decimal Price, int Stock);
}
