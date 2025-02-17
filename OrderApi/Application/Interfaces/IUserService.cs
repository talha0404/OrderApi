using OrderApi.Application.Common.Result;
using OrderApi.Application.DTOs;

namespace OrderApi.Application.Interfaces;

public interface IUserService : IBaseService<UserDto>
{
    Task<Result<UserDto>> GetUserByEmailAsync(string email);
    Task<Result<IEnumerable<UserDto>>> GetUsersSpentOverThousand();
}