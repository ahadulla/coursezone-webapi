namespace CourseZone.Domain.Exceptions.Courses;

public class CourseTypeNotFoundException : NotFoundException
{
    public CourseTypeNotFoundException()
    {
        this.TitleMessage = "Course type not found";
    }
}
