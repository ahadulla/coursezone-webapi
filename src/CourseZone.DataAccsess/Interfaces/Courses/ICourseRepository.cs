using CourseZone.DataAccsess.Common.Interfaces;
using CourseZone.DataAccsess.ViewModels.Courses;
using CourseZone.Domain.Entites.Courses;

namespace CourseZone.DataAccsess.Interfaces.Courses;

public interface ICourseRepository : IRepository<Course, CourseViewModel>,
    IGetAll<CourseViewModel>, ISearchable<CourseViewModel>
{
    public Task<Course?> GetByIdAsyncSpecial(long id);
}
