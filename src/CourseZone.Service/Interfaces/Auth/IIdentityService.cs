using CourseZone.Domain.Enums;

namespace CourseZone.Service.Interfaces.Auth;

public interface IIdentityService
{
    public long UserId { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Email { get; }

    public IdentityRole? IdentityRole { get; }
}
