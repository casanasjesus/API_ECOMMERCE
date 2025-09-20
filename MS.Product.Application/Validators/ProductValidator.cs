using FluentValidation;
using MSProduct.Domain;

namespace MSProduct.Application.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .WithMessage("Product name is required")
                .MaximumLength(100)
                .WithMessage("Product name cannot exceed 100 characters");

            RuleFor(product => product.Description)
                .MaximumLength(4000)
                .WithMessage("Description cannot exceed 4000 characters");

            RuleFor(product => product.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be greater than or equal to 0");

            RuleFor(product => product.Stock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Stock must be greater than or equal to 0");
        }
    }
}
