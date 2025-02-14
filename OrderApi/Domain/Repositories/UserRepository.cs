using Microsoft.EntityFrameworkCore;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;
using OrderApi.Infrastructure.Data;

namespace OrderApi.Domain.Repositories;

public class UserRepository: BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User?> GetUserByIdAsync(int userId) => await _dbSet.FirstOrDefaultAsync(o => o.Id == userId);
    public async Task<User?> GetUserByEmailAsync(string email) => await _dbSet.FirstOrDefaultAsync(o => o.Email == email);

    public async Task<List<User?>> GetUsersSpentOverThousand()
    {
        var data = await _context.OrderDetails
            .Join(_context.Products.AsNoTracking(), 
                orderDetail => orderDetail.ProductId, 
                product => product.Id, 
                (orderDetail, product) => new
                {
                    orderDetail.OrderId,
                    orderDetail.Quantity,
                    ProductPrice = product.Price
                })
            .Join(_context.Orders.AsNoTracking(),
                orderDetailProduct => orderDetailProduct.OrderId,
                order => order.Id,
                (orderDetailProduct, order) => new
                {
                    orderDetailProduct.OrderId,
                    order.UserId,
                    Revenue = orderDetailProduct.Quantity * orderDetailProduct.ProductPrice
                })
            .Join(_context.Users.AsNoTracking(), 
                orderWithRevenue => orderWithRevenue.UserId,
                user => user.Id,
                (orderWithRevenue, user) => new
                {
                    user,
                    user.Id,
                    user.Name,
                    user.Email,
                    orderWithRevenue.OrderId,
                    Revenue = orderWithRevenue.Revenue
                })
            .GroupBy(x=> new { x.Id, x.OrderId, x.Name, x.Email})
            .Select(g => new
            {
                g.Key.Id,
                g.Key.Name,
                g.Key.Email,
                TotalRevenue = g.Sum(x => x.Revenue)
            })
            .Where(x=>x.TotalRevenue > 1000)
            .OrderByDescending(x=>x.TotalRevenue)
            .Select(x => new User
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email
            })
            .ToListAsync();
        
        return data;
    }
}