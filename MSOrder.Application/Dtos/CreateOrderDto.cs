namespace MSOrder.Application.Dtos
{
    public record CreateOrderDto(
        int customerId,
        List<CreateOrderItemRequest> items,
        OrderStatusRequest status,
        OrderAddressRequest orderAddress
    );
}
