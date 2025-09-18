namespace MSCustomer.Application.Dtos
{
    public record CreateCustomerDto(string Name, string LastName, string Email, string? Address, DateTime DateRegister);
}
