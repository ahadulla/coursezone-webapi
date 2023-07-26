using CourseZone.DataAccsess.Common.Interfaces;
using CourseZone.DataAccsess.Utils;
using CourseZone.Domain.Entites.CourseZonePoints;

namespace CourseZone.DataAccsess.Interfaces.CourseZonePoints;

public interface ICourseZonePointRepository : IGetAll<CourseZonePoint>
{
    public Task<int> CreateCourseZonePointsAsync(CourseZonePoint entity);

}
