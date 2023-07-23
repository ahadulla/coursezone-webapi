using CourseZone.Service.Dtos.Auth;

namespace CourseZone.Service.Interfaces.Auth;

public interface IAuthService
{
    public Task<(bool Result, int CachedMinutes)> RegisterAsync(RegisterDto dto);

    public Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string email);

    public Task<(bool Result, string Token)> VerifyRegisterAsync(string email, int code);

    public Task<(bool Result, string Token)> LoginAsync(LoginDto loginDto);

}
