﻿using CourseZone.Service.Dtos.Auth;
using CourseZone.Service.Interfaces.Auth;
using CourseZone.Service.Validators;
using CourseZone.Service.Validators.Dtos.Auth;
using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync([FromForm] RegisterDto registerDto)
    {
        var validator = new RegisterValidator();
        var result = validator.Validate(registerDto);
        if (result.IsValid)
        {
            var serviceResult = await _authService.RegisterAsync(registerDto);
            return Ok(new { serviceResult.Result, serviceResult.CachedMinutes });
        }
        else return BadRequest(result.Errors);
    }

    [HttpPost("register/send-code")]
    [AllowAnonymous]
    public async Task<IActionResult> SendCodeRegisterAsync(string email)
    {
        var result = EmailValidator.IsValid(email);
        if (result == false) return BadRequest("Email number is invalid!");

        var serviceResult = await _authService.SendCodeForRegisterAsync(email);
        return Ok(new { serviceResult.Result, serviceResult.CachedVerificationMinutes });
    }

    [HttpPost("register/verify")]
    [AllowAnonymous]
    public async Task<IActionResult> VerifyRegisterAsync([FromBody] VerifyRegisterDto verifyRegisterDto)
    {
        var serviceResult = await _authService.VerifyRegisterAsync(verifyRegisterDto.Email, verifyRegisterDto.Code);
        return Ok(new { serviceResult.Result, serviceResult.Token });
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
    {
        var validator = new LoginValidator();
        var valResult = validator.Validate(loginDto);
        if (valResult.IsValid == false) return BadRequest(valResult.Errors);

        var serviceResult = await _authService.LoginAsync(loginDto);
        return Ok(new { serviceResult.Result, serviceResult.Token });
    }

}
