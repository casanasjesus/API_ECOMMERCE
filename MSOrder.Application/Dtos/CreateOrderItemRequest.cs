namespace MSOrder.Application.Dtos
{
    public class CreateOrderItemRequest
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}