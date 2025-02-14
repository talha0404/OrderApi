using Microsoft.EntityFrameworkCore;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;
using OrderApi.Infrastructure.Data;

namespace OrderApi.Domain.Repositories;

public class OrderRepository: BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Order>> GetOrdersByUserIdAsync(int userId) => 
        await _dbSet.Where(o => o.UserId == userId).ToListAsync();

    public async Task<decimal> GetTotalRevenueAllOrder()
    {
        var revenuesOfProducts = await _context.OrderDetails
            .Join(_context.Products, 
                orderDetail => orderDetail.ProductId, 
                product => product.Id, 
                (orderDetail, product) => new
                {
                    totalPrice = product.Price * orderDetail.Quantity 
                }).SumAsync(x => x.totalPrice);

        return revenuesOfProducts;
    }
}