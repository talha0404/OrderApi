using OrderApi.Application.DTOs;

namespace OrderApi.Application.Interfaces;

public interface IUserService : IBaseService<UserDto>
{
    Task<UserDto?> GetUserByEmailAsync(string email);
    Task<IEnumerable<UserDto?>> GetUsersSpentOverThousand();
}