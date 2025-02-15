using AutoMapper;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;

namespace OrderApi.Application.Services;

public class OrderService: BaseService<Order, OrderDto>, IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILoggerService _logger;
    
    public OrderService(
        IOrderRepository orderRepository, 
        IMapper mapper,
        ILoggerService logger) : base(orderRepository, mapper, logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId)
    {
        try
        {
            _logger.LogInformation($"Getting orders for user ID: {userId}");
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            _logger.LogDebug($"Retrieved {orders.Count} orders for user ID: {userId}");
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving orders for user ID: {userId}", ex);
            throw;
        }
    }

    public async Task<decimal> GetTotalRevenueAllOrder()
    {
        try
        {
            _logger.LogInformation("Calculating total revenue for all orders");
            var totalRevenue = await _orderRepository.GetTotalRevenueAllOrder();
            _logger.LogDebug($"Total revenue calculated: {totalRevenue}");
            return totalRevenue;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error calculating total revenue", ex);
            throw;
        }
    }
}