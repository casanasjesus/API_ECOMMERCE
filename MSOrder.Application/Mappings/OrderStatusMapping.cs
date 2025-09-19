using MSOrder.Application.Dtos;
using MSOrder.Domain;

namespace MSOrder.Application.Mappers
{
    public static class OrderStatusMapper
    {
        public static OrderStatus ToDomain(OrderStatusRequest status)
        {
            return status switch
            {
                OrderStatusRequest.Pending => OrderStatus.Pending,
                OrderStatusRequest.Processing => OrderStatus.Processing,
                OrderStatusRequest.Processed => OrderStatus.Processed,
                OrderStatusRequest.Cancelled => OrderStatus.Cancelled,
                _ => OrderStatus.Pending
            };
        }
    }
}