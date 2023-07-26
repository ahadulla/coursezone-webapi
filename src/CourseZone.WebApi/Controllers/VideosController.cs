using CourseZone.DataAccsess.Utils;
using CourseZone.Service.Dtos.Videos;
using CourseZone.Service.Interfaces.Videos;
using CourseZone.Service.Validators.Dtos.Videos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseZone.WebApi.Controllers;

[Route("api/videos")]
[ApiController]
public class VideosController : ControllerBase
{
    private readonly IVideoService _service;

    private readonly int maxPageSize = 30;

    public VideosController(IVideoService videoService)
    {
        this._service = videoService;
    }

    [HttpGet]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{videoId}")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] long videoId)
        => Ok(await _service.GetByIdAsync(videoId));

    [HttpGet("count")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CountAsynv() => Ok(await _service.CountAsync());

    [HttpPost]
    [RequestFormLimits(MultipartBodyLengthLimit = 314572801)]
    [RequestSizeLimit(314572801)]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> CreateAsync([FromForm] VideoCreateDto dto)
    {
        var createValidator = new VideoCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{videoId}")]
    [RequestFormLimits(MultipartBodyLengthLimit = 314572800)]
    [RequestSizeLimit(314572800)]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> UpdateAsync(long videoId, [FromForm] VideoUpdateDto dto)
    {
        var updateValidator = new VideoUpdateValidator();
        var result = updateValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.UpdateAsync(videoId, dto));
        else return BadRequest(result.Errors);
    }

    [HttpDelete("{videoId}")]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteAsync(long videoId)
        => Ok(await _service.DeleteAsync(videoId));

}
