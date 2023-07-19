using Microsoft.AspNetCore.Http;

namespace CourseZone.Service.Dtos.Categories;

public class CourseTypeUpdateDto
{
    public string Name { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public IFormFile? Image { get; set; }
}
