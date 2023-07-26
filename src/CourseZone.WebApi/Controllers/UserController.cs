using CourseZone.Service.Dtos.Users;
using CourseZone.Service.Interfaces.Users;
using CourseZone.Service.Validators.Dtos.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseZone.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserService _service;

    public UserController(IUserService userService)
    {
        this._service = userService;
    }

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync() => Ok(await _service.CountAsync());

    [HttpDelete("{userId}")]
    [Authorize(Roles = "User")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long userId) => Ok(await _service.DeleteAsync(userId));

    [HttpGet("{userId}")]
    [Authorize(Roles = "User")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetByIdAsync(long userId) => Ok(await _service.GetByIdAsync(userId));

    [HttpPut("{userId}")]
    [Authorize(Roles = "User")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long userId, [FromForm] UserUpdateDto dto)
    {
        var updateValidator = new UserUpdateValidator();
        var result = updateValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.UpdateAsync(userId, dto));
        else return BadRequest(result.Errors);
    }
}
