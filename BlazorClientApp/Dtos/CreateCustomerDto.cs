namespace BlazorClientApp.Dtos
{
    public class CreateCustomerDto
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateRegister { get; set; }
    }
}
