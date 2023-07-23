using CourseZone.Domain.Entites.Users;

namespace CourseZone.Service.Interfaces.Auth;

public interface ITokenService
{
    public Task<string> GenerateToken(User user);
}
