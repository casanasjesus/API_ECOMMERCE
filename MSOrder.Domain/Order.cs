namespace MSOrder.Domain
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public Address OrderAddress { get; set; }

        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public decimal TotalOrder { get; set; }

        public void AddOrderItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
            TotalOrder += orderItem.UnitPrice * orderItem.Amount;
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            var existingItem = OrderItems.FirstOrDefault(item => item.OrderItemId == orderItem.OrderItemId);

            if (existingItem != null)
            {
                OrderItems.Remove(existingItem);
                TotalOrder -= orderItem.UnitPrice * orderItem.Amount;
            }
        }
    }
}
