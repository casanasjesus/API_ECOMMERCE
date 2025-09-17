using Lab.Core;
using Lab.Domain.Enums;
using Lab.Domain.ValueObjects;

namespace Lab.Domain.Entities
{
    // Agregado
    public class Order : Aggregate
    {
        public DateTime Date { get; set; }

        public decimal Total { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Address ShippingAddress { get; set; }

        public Customer Customer { get; set; }

        public OrderStatus Status { get; set; }

        public void AddOrderItem(OrderItem item)
        {
            OrderItems.Add(item);
            Total += item.UnitPrice * item.Quantity;
        }

        public void RemoveOrderItem(OrderItem item)
        {
            var existingItem = OrderItems.FirstOrDefault(i => i.Id == item.Id);

            if (existingItem != null)
            {
                OrderItems.Remove(existingItem);
                Total -= item.UnitPrice * item.Quantity;
            }
        }
    }
}
