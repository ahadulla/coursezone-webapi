using Microsoft.AspNetCore.Http;

namespace CourseZone.Service.Dtos.Videos;

public class VideoCreateDto
{
    public long CourseId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IFormFile Video { get; set; } = default!;    
}
