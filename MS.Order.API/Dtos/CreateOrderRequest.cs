using MSOrder.Application.Dtos;

namespace MSOrder.API.Dtos
{
    public record CreateOrderRequest(
        int customerId,
        List<CreateOrderItemRequest> items,
        OrderStatusRequest status,
        OrderAddressRequest orderAddress
    );
}
