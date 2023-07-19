using Microsoft.AspNetCore.Http;

namespace CourseZone.Service.Dtos.Courses;

public class CourseTypeCreateDto
{
    public string Name { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public IFormFile Image { get; set; } = default!;
}
