using Microsoft.AspNetCore.Http;

namespace CourseZone.Service.Dtos.Videos;

public class VideoUpdateDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IFormFile? Video { get; set; }

    public IFormFile? Image { get; set; }
}
