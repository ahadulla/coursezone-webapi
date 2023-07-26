using CourseZone.DataAccsess.Utils;
using CourseZone.Domain.Entites.Users;
using CourseZone.Service.Dtos.Users;

namespace CourseZone.Service.Interfaces.Users;

public interface IUserService
{
    public Task<bool> DeleteAsync(long userId);

    public Task<long> CountAsync();

    public Task<IList<User>> GetAllAsync(PaginationParams @params);

    public Task<User> GetByIdAsync(long userId);

    public Task<bool> UpdateAsync(long userId, UserUpdateDto dto);
}
