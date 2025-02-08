using OrderApi.Domain.Entities;

namespace OrderApi.Domain.Interfaces;

public interface IOrderRepository: IBaseRepository<Order>
{
    Task<List<Order>> GetOrdersByUserIdAsync(int userId);
}