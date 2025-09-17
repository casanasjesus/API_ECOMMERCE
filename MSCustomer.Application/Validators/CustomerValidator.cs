using FluentValidation;
using MSCustomer.Domain;

namespace MSCustomer.Application.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Customer name is required")
                .MaximumLength(20)
                .WithMessage("Customer name cannot exceed 10 characters");

            RuleFor(p => p.LastName)
                .NotEmpty()
                .WithMessage("Customer last name is required")
                .MaximumLength(20)
                .WithMessage("Last name cannot exceed 20 characters");

            RuleFor(p => p.Email)
                .MaximumLength(100)
                .WithMessage("Email cannot exceed 100 characters");

            RuleFor(p => p.DateRegister)
                .NotEmpty()
                .WithMessage("Date register is required");
        }
    }
}
