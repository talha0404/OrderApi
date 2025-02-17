using Microsoft.AspNetCore.Mvc;
using OrderApi.Application.Common.Result;

namespace OrderApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    // This will be inherited by all controllers

    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result == null)
            return BadRequest();

        if (!result.IsSuccess)
            return BadRequest(new { message = result.Message });

        if (result.Data == null)
            return NotFound(new { message = result.Message });

        return Ok(result.Data);
    }

    protected IActionResult HandleCreatedResult<T>(Result<T> result, string actionName, object routeValues)
    {
        if (!result.IsSuccess)
            return BadRequest(new { message = result.Message });

        return CreatedAtAction(actionName, routeValues, result.Data);
    }

    protected IActionResult HandleNoContentResult<T>(Result<T> result)
    {
        if (!result.IsSuccess)
            return BadRequest(new { message = result.Message });

        return NoContent();
    }

}