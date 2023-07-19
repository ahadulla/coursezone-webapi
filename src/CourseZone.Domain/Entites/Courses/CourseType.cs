using System.ComponentModel.DataAnnotations;

namespace CourseZone.Domain.Entites.Courses;

public class CourseType : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;
}
