using Microsoft.EntityFrameworkCore;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;
using OrderApi.Infrastructure.Data;

namespace OrderApi.Domain.Repositories;

public class ProductRepository: BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetByCategoryIdAsync(int categoryId)
    {
        try
        {
            var data = await _context.Products.Where(p=>p.CategoryId == categoryId).ToListAsync();
            var data2 = await _dbSet.Where(p => p.CategoryId == categoryId).ToListAsync();
            return data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Product?> GetMostExpensiveProduct()
    {
        var data = await _context.Products.OrderByDescending(p => p.Price).FirstOrDefaultAsync();
        return data;
    }

    public async Task<decimal> GetAveragePricesElectronicsProduct()
    {
        var data = await _context.Products.Where(p=>p.CategoryId == 1 ).ToListAsync();
        var avaragePrice = data.Average(p => p.Price);
        return avaragePrice;
    }
}