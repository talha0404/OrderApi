using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;
using OrderApi.Infrastructure.Data;

namespace OrderApi.Domain.Repositories;

public class UserRepository: BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}