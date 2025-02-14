using AutoMapper;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;

namespace OrderApi.Application.Services;

public class UserService: BaseService<User, UserDto>, IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserDto?> GetUserByEmailAsync(string email)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        return _mapper.Map<UserDto>(user);
    }
    
    
    public async Task<IEnumerable<UserDto?>> GetUsersSpentOverThousand()
    {
        var user = await _userRepository.GetUsersSpentOverThousand();
        return _mapper.Map<IEnumerable<UserDto>>(user);
    }
}