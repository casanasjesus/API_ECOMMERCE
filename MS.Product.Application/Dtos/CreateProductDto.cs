namespace MSProduct.Application.Dtos
{
    public record CreateProductDto(string Name, string? Description, decimal Price, int Stock);
}
