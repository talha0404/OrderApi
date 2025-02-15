using AutoMapper;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;

namespace OrderApi.Application.Services;

public class UserService: BaseService<User, UserDto>, IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILoggerService _logger;

    public UserService(
        IUserRepository userRepository, 
        IMapper mapper,
        ILoggerService logger) : base(userRepository, mapper, logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }
    
    public async Task<UserDto?> GetUserByEmailAsync(string email)
    {
        try
        {
            _logger.LogInformation($"Getting user by email: {email}");
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                _logger.LogWarning($"User not found with email: {email}");
            }
            return _mapper.Map<UserDto>(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving user by email: {email}", ex);
            throw;
        }
    }
    
    public async Task<IEnumerable<UserDto?>> GetUsersSpentOverThousand()
    {
        try
        {
            _logger.LogInformation("Getting users who spent over thousand");
            var users = await _userRepository.GetUsersSpentOverThousand();
            _logger.LogDebug($"Retrieved {users.Count} users who spent over thousand");
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error retrieving users who spent over thousand", ex);
            throw;
        }
    }
}