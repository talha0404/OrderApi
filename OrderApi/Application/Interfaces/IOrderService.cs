using OrderApi.Application.Common.Result;
using OrderApi.Application.DTOs;

namespace OrderApi.Application.Interfaces;

public interface IOrderService : IBaseService<OrderDto>
{
    Task<Result<IEnumerable<OrderDto>>> GetOrdersByUserIdAsync(int userId);
    Task<Result<decimal>> GetTotalRevenueAllOrder();
}