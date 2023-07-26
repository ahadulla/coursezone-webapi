using CourseZone.DataAccsess.Common.Interfaces;
using CourseZone.Domain.Entites.Courses;

namespace CourseZone.DataAccsess.Interfaces.Courses;

public interface ICourseTypeRepository : IRepository<CourseType, CourseType>,
    IGetAll<CourseType>
{

}
