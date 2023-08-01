using CourseZone.DataAccsess.Interfaces.Users;
using CourseZone.DataAccsess.Utils;
using CourseZone.Domain.Entites.Users;
using CourseZone.Domain.Enums;
using CourseZone.Domain.Exceptions.Users;
using CourseZone.Service.Common.Helpers;
using CourseZone.Service.Dtos.Users;
using CourseZone.Service.Interfaces.Auth;
using CourseZone.Service.Interfaces.Users;

namespace CourseZone.Service.Services.UserService;

public class UserService : IUserService
{
    private IUserRepository _repository;
    private IIdentityService _identity;

    public UserService(IUserRepository userRepository, IIdentityService identityService)
    {
        this._repository = userRepository;
        this._identity = identityService;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> DeleteAsync(long userId)
    {
        if (userId != _identity.UserId && _identity.IdentityRole != IdentityRole.Admin) throw new UserNotFoundExcaption();
        var result = await _repository.DeleteAsync(userId);
        return result > 0;
    }

    public Task<IList<User>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetByIdAsync(long userId)
    {
        var user = await _repository.GetByIdAsync(userId);
        if (user is null) throw new UserNotFoundExcaption();
        else return user;
    }

    public async Task<bool> UpdateAsync(long userId, UserUpdateDto dto)
    {
        var user = await _repository.GetByIdAsync(userId);
        if (user is null) throw new UserNotFoundExcaption();
        if (userId != _identity.UserId && _identity.IdentityRole != IdentityRole.Admin) throw new UserNotFoundExcaption();

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.PhoneNumber = dto.PhoneNumber;

        user.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(userId, user);
        return dbResult > 0;
    }
}
