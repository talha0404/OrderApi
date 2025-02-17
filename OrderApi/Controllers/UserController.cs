using Microsoft.AspNetCore.Mvc;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;

namespace OrderApi.Controllers;

public class UserController : BaseApiController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _userService.GetAllAsync();

        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _userService.GetByIdAsync(id);
        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserDto userDto)
    {
        var result = await _userService.AddAsync(userDto);

        return HandleCreatedResult(result, nameof(GetById), new { id = result.Data.Id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UserDto userDto)
    {
        var result = await _userService.UpdateAsync(id, userDto);
        return HandleResult(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _userService.DeleteAsync(id);
        return HandleNoContentResult(result);
    }

    [HttpGet("GetUsersSpentOverThousand")]
    public async Task<IActionResult> GetUsersSpentOverThousand()
    {
        var result = await _userService.GetUsersSpentOverThousand();
        return HandleResult(result);
    }
}