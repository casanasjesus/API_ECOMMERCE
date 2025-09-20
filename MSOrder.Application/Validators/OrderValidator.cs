using FluentValidation;
using MSOrder.Domain;

namespace MSOrder.Application.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(order => order.OrderDate)
                .NotNull()
                .NotEmpty()
                .WithMessage("Order date is required")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Order date cannot be in the future");

            RuleFor(order => order.OrderStatus)
                .NotNull()
                .IsInEnum()
                .WithMessage("Invalid order status");

            RuleFor(order => order.OrderAddress)
                .NotNull()
                .WithMessage("Order address is required");

            RuleFor(order => order.Customer)
                .NotNull()
                .WithMessage("Customer is required");

            RuleFor(order => order.OrderItems)
                .NotNull()
                .NotEmpty()
                .WithMessage("Order must contain at least one item");

            RuleForEach(order => order.OrderItems).ChildRules(orderItem =>
            {
                orderItem.RuleFor(i => i.ProductId)
                    .GreaterThan(0)
                    .WithMessage("Invalid product ID");

                orderItem.RuleFor(i => i.Amount)
                    .GreaterThan(0)
                    .WithMessage("Amount must be greater than 0");

                orderItem.RuleFor(i => i.UnitPrice)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Unit price must be greater than or equal to 0");
            });

            RuleFor(order => order.TotalOrder)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Total order must be greater than or equal to 0");
        }
    }
}
