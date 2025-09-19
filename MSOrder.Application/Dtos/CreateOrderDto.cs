using MSOrder.Domain;

namespace MSOrder.Application.Dtos
{
    public record CreateOrderDto(int customerId, List<OrderItem> items, OrderStatus status, Address orderAddress);
}
