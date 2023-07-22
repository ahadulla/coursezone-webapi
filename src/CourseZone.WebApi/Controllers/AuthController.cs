using CourseZone.Domain.Enums;
using CourseZone.Service.Dtos.Auth;
using CourseZone.Service.Interfaces.Auth;
using CourseZone.Service.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CourseZone.WebApi.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        this._authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromForm] RegisterDto registerDto)
    {
        var serviceResult = await _authService.RegisterAsync(registerDto);
        return Ok(new { serviceResult.Result, serviceResult.CachedMinutes });
    }

    [HttpPost("register/send-code")]
    public async Task<IActionResult> SendCodeRegisterAsync(string email)
    {
        var serviceResult = await _authService.SendCodeForRegisterAsync(email);
        return Ok(new { serviceResult.Result, serviceResult.CachedVerificationMinutes });
    }

    [HttpPost("register/verify")]
    public async Task<IActionResult> VerifyRegisterAsync([FromBody] VerifyRegisterDto verifyRegisterDto)
    {
        var serviceResult = await _authService.VerifyRegisterAsync(verifyRegisterDto.Email, verifyRegisterDto.Code);
        return Ok(new { serviceResult.Result, serviceResult.Token });
    }

}
