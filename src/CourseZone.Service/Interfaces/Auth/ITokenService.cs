using CourseZone.Domain.Entites.Users;

namespace CourseZone.Service.Interfaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);
}
