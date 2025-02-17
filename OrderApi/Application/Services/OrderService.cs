using AutoMapper;
using OrderApi.Application.Common.Result;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;
using OrderApi.Infrastructure.Logging;

namespace OrderApi.Application.Services;

public class OrderService : BaseService<Order, OrderDto>, IOrderService
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

    public async Task<Result<IEnumerable<OrderDto>>> GetOrdersByUserIdAsync(int userId)
    {
        try
        {
            _logger.LogInformation($"Getting orders for user ID: {userId}");
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Result<IEnumerable<OrderDto>>.Success(orderDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving orders for user ID: {userId}", ex);
            return Result<IEnumerable<OrderDto>>.Failure(ex.Message);
        }
    }

    public async Task<Result<decimal>> GetTotalRevenueAllOrder()
    {
        try
        {
            _logger.LogInformation("Calculating total revenue for all orders");
            var totalRevenue = await _orderRepository.GetTotalRevenueAllOrder();
            return Result<decimal>.Success(totalRevenue);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error calculating total revenue", ex);
            return Result<decimal>.Failure(ex.Message);
        }
    }
}