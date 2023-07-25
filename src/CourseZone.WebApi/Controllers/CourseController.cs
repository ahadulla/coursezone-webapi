using CourseZone.DataAccsess.Utils;
using CourseZone.Service.Dtos.Courses;
using CourseZone.Service.Interfaces.Courses;
using CourseZone.Service.Validators.Dtos.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseZone.WebApi.Controllers;

[Route("api/courses")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _service;
    private readonly int maxPageSize = 30;

    public CourseController(ICourseService courseService)
    {
        _service = courseService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));


    [HttpGet("{courseId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long courseId)
        =>Ok(await _service.GetByIdAsync(courseId));

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync() 
        => Ok(await _service.CountAsync());

    [HttpPost]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> CreateAsync([FromForm] CourseCreateDto dto)
    {
        var createValidator = new CourseCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{courseId}")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> UpdateAsync(long courseId, [FromForm] CourseUpdateDto dto)
    {
        var updateValidator = new CourseUpdateValidator();
        var result = updateValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.UpdateAsync(courseId, dto));
        else return BadRequest(result.Errors);
    }

    [HttpDelete("{courseId}")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> DeleteAsync(long courseId)
        => Ok(await _service.DeleteAsync(courseId));
}
