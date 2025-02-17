using AutoMapper;
using OrderApi.Application.Common.Result;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Interfaces;
using OrderApi.Infrastructure.Logging;

namespace OrderApi.Application.Services;

public class UserService : BaseService<User, UserDto>, IUserService
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

    public async Task<Result<UserDto>> GetUserByEmailAsync(string email)
    {
        try
        {
            _logger.LogInformation($"Getting user by email: {email}");
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
                return Result<UserDto>.Failure("Kullanıcı bulunamadı");

            var userDto = _mapper.Map<UserDto>(user);
            return Result<UserDto>.Success(userDto);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving user by email: {email}", ex);
            return Result<UserDto>.Failure(ex.Message);
        }
    }

    public async Task<Result<IEnumerable<UserDto>>> GetUsersSpentOverThousand()
    {
        try
        {
            _logger.LogInformation("Getting users who spent over thousand");
            var users = await _userRepository.GetUsersSpentOverThousand();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return Result<IEnumerable<UserDto>>.Success(userDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error retrieving users who spent over thousand", ex);
            return Result<IEnumerable<UserDto>>.Failure(ex.Message);
        }
    }
}