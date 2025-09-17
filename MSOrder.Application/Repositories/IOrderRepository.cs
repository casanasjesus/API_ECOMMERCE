using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSOrder.Domain;

namespace MSOrder.Application.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
    }
}
