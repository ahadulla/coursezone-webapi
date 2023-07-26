using CourseZone.DataAccsess.Interfaces.Users;
using CourseZone.DataAccsess.Utils;
using CourseZone.Domain.Entites.Courses;
using CourseZone.Domain.Entites.Users;
using CourseZone.Domain.Exceptions.Courses;
using CourseZone.Domain.Exceptions.Files;
using CourseZone.Domain.Exceptions.Users;
using CourseZone.Service.Common.Helpers;
using CourseZone.Service.Dtos.Users;
using CourseZone.Service.Interfaces.Users;

namespace CourseZone.Service.Services.UserService;

public class UserService : IUserService
{
    private IUserRepository _repository;

    public UserService(IUserRepository userRepository)
    {
        this._repository = userRepository;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> DeleteAsync(long userId) => await _repository.DeleteAsync(userId) > 0;

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

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.PhoneNumber = dto.PhoneNumber;
       
        user.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(userId, user);
        return dbResult > 0;
    }
}
