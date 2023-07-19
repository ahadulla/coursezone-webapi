namespace CourseZone.Domain.Exceptions.Users;

public class UserNotFoundExcaption : NotFoundException
{
    public UserNotFoundExcaption()
    {
        this.TitleMessage = "User not found";
    }
}
