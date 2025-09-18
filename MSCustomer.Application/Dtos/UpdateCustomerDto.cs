namespace MSCustomer.Application.Dtos
{
    public record UpdateCustomerDto(string Name, string LastName, string Email, string? Address, DateTime DateRegister);
}
