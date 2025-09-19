namespace MSOrder.Application.Dtos
{
    public record CustomerDto(int Id, string Name, string LastName, string Email, string? Address, DateTime DateRegister);
}
