using MSOrder.Domain;

namespace MSOrder.API.Dtos
{
    public record CreateOrderRequest(int customerId, List<OrderItem> items, OrderStatus status, Address orderAddress);
}
