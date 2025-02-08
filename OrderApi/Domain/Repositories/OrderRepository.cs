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
}