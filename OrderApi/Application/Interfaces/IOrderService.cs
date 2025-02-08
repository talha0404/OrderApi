using OrderApi.Application.DTOs;

namespace OrderApi.Application.Interfaces;

public interface IOrderService: IBaseService<OrderDto>
{
    Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId);
}