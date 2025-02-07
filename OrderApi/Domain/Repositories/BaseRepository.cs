using Microsoft.EntityFrameworkCore;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;
using OrderApi.Infrastructure.Data;

namespace OrderApi.Domain.Repositories;

public class BaseRepository<T>: IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

    public async Task<T?> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

    public async Task AddAsync(T entity)
    {
        _context.Set<T>().Add(entity); 
        await _context.SaveChangesAsync(); 
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity); await _context.SaveChangesAsync(); 
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id); 
        if (entity != null) {
            _context.Set<T>().Remove(entity); 
            await _context.SaveChangesAsync(); 
        } 
    }
}