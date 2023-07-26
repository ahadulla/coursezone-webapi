namespace CourseZone.Domain.Entites.CourseZonePoints;

public class CourseZonePoint : BaseEntity
{
    public long OrderId { get; set; }

    public double Price { get; set; }

    public DateTime CreateAt { get; set; }
}
