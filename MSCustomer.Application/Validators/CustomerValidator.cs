using FluentValidation;
using MSCustomer.Domain;

namespace MSCustomer.Application.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Customer name is required")
                .MaximumLength(20)
                .WithMessage("Customer name cannot exceed 10 characters");

            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("Customer last name is required")
                .MaximumLength(20)
                .WithMessage("Last name cannot exceed 20 characters");

            RuleFor(c => c.Email)
                .MaximumLength(100)
                .WithMessage("Email cannot exceed 100 characters");

            RuleFor(c => c.Address)
                .MaximumLength(100)
                .WithMessage("Address cannot exceed 100 characters");

            RuleFor(c => c.DateRegister)
                .NotEmpty()
                .WithMessage("Date register is required");
        }
    }
}
