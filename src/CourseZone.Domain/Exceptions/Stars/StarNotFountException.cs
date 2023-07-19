namespace CourseZone.Domain.Exceptions.Stars;

public class StarNotFountException : NotFoundException
{
    public StarNotFountException()
    {
        this.TitleMessage = "Ster not found";
    }
}
