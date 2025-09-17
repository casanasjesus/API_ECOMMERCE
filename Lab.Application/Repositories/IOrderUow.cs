using Lab.Domain.Entities;

namespace Lab.Application.Repositories
{
    public interface IOrderUow
    {
        int CreateNewOrderWithCustomer(Order order, Customer customer);
    }
}
