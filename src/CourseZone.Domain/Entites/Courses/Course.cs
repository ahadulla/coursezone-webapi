namespace CourseZone.Domain.Entites.Courses;

public class Course : Auditable
{
    public string Language { get; set; } = string.Empty;

    public long UserId { get; set; }

    public long CourseTypeId { get; set; }

    public string Name { get; set; } = string.Empty;

    public double Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

}
