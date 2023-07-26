using CourseZone.Domain.Entites.Stars;
using CourseZone.Service.Interfaces.Stars;
using CourseZone.Service.Validators.Dtos.Stars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseZone.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StarsController : ControllerBase
{
    private IStarService _service;

    public StarsController(IStarService starService)
    {
        this._service = starService;
    }

    [HttpPost]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> CreateAsync([FromQuery] Star dto)
    {
        var createValidator = new StarCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }
}
