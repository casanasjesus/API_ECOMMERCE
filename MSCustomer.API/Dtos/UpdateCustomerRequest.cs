namespace MSCustomer.API.Dtos
{
    public record UpdateCustomerRequest(string Name, string LastName, string Email, string? Address, DateTime DateRegister);
}