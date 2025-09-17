using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSOrder.Application.Repositories;
using MSOrder.Domain;

namespace MSOrder.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
