namespace CourseZone.Domain.Entites.Videas;

public class Video : Auditable
{
    public long CourseId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string VideoPath { get; set; } = string.Empty;
}
