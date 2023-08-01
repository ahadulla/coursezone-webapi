using Microsoft.AspNetCore.Http;

namespace CourseZone.Service.Dtos.Courses;

public class CourseCreateDto
{
    public string Language { get; set; } = string.Empty;

    public long TypeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public float Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public IFormFile Image { get; set; } = default!;

}
