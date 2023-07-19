namespace CourseZone.Domain.Entites.Stars;

public class Star : BaseEntity
{
    public long UserId { get; set; }

    public long CourseId { get; set; }

    public int StarCount { get; set; }
}
