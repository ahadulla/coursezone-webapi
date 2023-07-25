using CourseZone.Service.Validators.Dtos.Categories;
using CourseZone.DataAccsess.Utils;
using CourseZone.Service.Dtos.Categories;
using CourseZone.Service.Dtos.Courses;
using CourseZone.Service.Interfaces.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CourseZone.WebApi.Controllers;

[Route("api/types")]
[ApiController]
public class CourseTypeController : ControllerBase
{
    private readonly ICourseTypeService _service;
    private readonly int maxPageSize = 30;
    public CourseTypeController(ICourseTypeService service)
    {
        this._service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{typeId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long typeId)
        => Ok(await _service.GetByIdAsync(typeId));

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] CourseTypeCreateDto dto)
    {
        var createValidator = new CourseTypeCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{typeId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long typeId, [FromForm] CourseTypeUpdateDto dto)
    {
        var updateValidator = new CourseTypeUpdateValidator();
        var validationResult = updateValidator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _service.UpdateAsync(typeId, dto));
        return BadRequest(validationResult.Errors);
    }

    [HttpDelete("{typeId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long typeId)
        => Ok(await _service.DeleteAsync(typeId));
}
