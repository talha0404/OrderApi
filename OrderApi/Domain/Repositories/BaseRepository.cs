using Microsoft.EntityFrameworkCore;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;
using OrderApi.Infrastructure.Data;

namespace OrderApi.Domain.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
    public async Task<TEntity?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var createdEntity = await _dbSet.AddAsync(entity); 
        await _context.SaveChangesAsync();
        return createdEntity.Entity;
    }
    public virtual async Task<TEntity> UpdateAsync(int id, TEntity entity)
    {
        var existingEntity = await _dbSet.FindAsync(id);

        if (existingEntity == null)
            throw new KeyNotFoundException("Entity not found");

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();

        return existingEntity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null) return false;
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
