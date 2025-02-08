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

}