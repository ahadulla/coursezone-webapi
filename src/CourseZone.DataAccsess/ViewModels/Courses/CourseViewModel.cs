using CourseZone.Domain.Entites;

namespace CourseZone.DataAccsess.ViewModels.Courses;

public class CourseViewModel : Auditable
{

    public string Language { get; set; } = string.Empty;

    public string Creator { get; set; } = string.Empty;

    public string CourseType { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public float Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public float StarCount { get; set; }

}
