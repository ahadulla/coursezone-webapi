using CourseZone.DataAccsess.Common.Interfaces;
using CourseZone.Domain.Entites.Users;

namespace CourseZone.DataAccsess.Interfaces.Users;

public interface IUserRepository : IRepository<User,User> , IGetAll<User>, ISearchable<User>
{
}
