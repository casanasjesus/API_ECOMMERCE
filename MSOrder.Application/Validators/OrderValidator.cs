using FluentValidation;
using MSOrder.Domain;

namespace MSOrder.Application.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {

        }
    }
}
