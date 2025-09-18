namespace MSCustomer.API.Dtos
{
    public record CreateCustomerRequest(string Name, string LastName, string Email, string? Address, DateTime DateRegister);
}
