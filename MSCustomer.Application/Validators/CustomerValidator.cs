using FluentValidation;
using MSCustomer.Domain;

namespace MSCustomer.Application.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Name)
                .NotEmpty()
                .WithMessage("Customer name is required")
                .MaximumLength(20)
                .WithMessage("Customer name cannot exceed 10 characters");

            RuleFor(customer => customer.LastName)
                .NotEmpty()
                .WithMessage("Customer last name is required")
                .MaximumLength(20)
                .WithMessage("Last name cannot exceed 20 characters");

            RuleFor(customer => customer.Email)
                .MaximumLength(100)
                .WithMessage("Email cannot exceed 100 characters");

            RuleFor(customer => customer.Address)
                .MaximumLength(100)
                .WithMessage("Address cannot exceed 100 characters");

            RuleFor(customer => customer.DateRegister)
                .NotEmpty()
                .WithMessage("Date register is required");
        }
    }
}
