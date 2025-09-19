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
            orderItem.SubTotal = orderItem.UnitPrice * orderItem.Amount;
            OrderItems.Add(orderItem);
            TotalOrder += orderItem.SubTotal;
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
