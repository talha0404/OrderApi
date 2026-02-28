using OrderApi.Domain.Entities;

namespace OrderApi.Domain.Interfaces;

public interface IUserRepository: IBaseRepository<User>
{
    Task<User?> GetUserByIdAsync(int userId); 
    Task<User?> GetUserByEmailAsync(string email);
    Task<List<User?>> GetUsersSpentOverThousand();
}