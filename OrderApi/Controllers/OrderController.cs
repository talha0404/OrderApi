using Microsoft.AspNetCore.Mvc;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;

namespace OrderApi.Controllers;

public class OrderController : BaseApiController
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _orderService.GetAllAsync();
        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _orderService.GetByIdAsync(id);
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(OrderDto orderDto)
    {
        var result = await _orderService.AddAsync(orderDto);
        return HandleCreatedResult(result, nameof(GetById), new { id = result.Data.Id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, OrderDto orderDto)
    {
        var result = await _orderService.UpdateAsync(id, orderDto);
        return HandleNoContentResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _orderService.DeleteAsync(id);
        return HandleNoContentResult(result);
    }

    [HttpGet("GetTotalRevenueAllOrders")]
    public async Task<IActionResult> GetTotalRevenueAllOrders()
    {
        var result = await _orderService.GetTotalRevenueAllOrder();
        return HandleResult(result);
    }
}

