using Lab.Core;
using Lab.Domain.Dtos;
using Lab.Domain.Entities;

namespace Lab.Application.Repositories
{
    public interface IOrderRepository
    {
        Task<Result<List<OrderDto>>> GetAllAsync();

        Task<Result<Order>> GetByIdAsync(int id);
        
        Result Add(Order order);
        
        Result Update(int id, Order order);
        
        Result Delete(int id);
    }
}
