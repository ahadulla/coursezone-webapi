namespace CourseZone.Domain.Exceptions.CourseZonePoints;

public class PointNotFound : NotFoundException
{
    public PointNotFound()
    {
        this.TitleMessage = "Point not found";
    }
}
