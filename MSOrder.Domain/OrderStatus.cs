using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSOrder.Domain
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Processed,
        Cancelled
    }
}
