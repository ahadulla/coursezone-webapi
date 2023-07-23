using CourseZone.DataAccsess.Utils;
using CourseZone.DataAccsess.ViewModels.Courses;
using CourseZone.Service.Dtos.Courses;

namespace CourseZone.Service.Interfaces.Courses;

public interface ICourseService
{
    public Task<bool> CreateAsync(CourseCreateDto dto);

    public Task<bool> DeleteAsync(long CourseId);

    public Task<long> CountAsync();

    public Task<IList<CourseViewModel>> GetAllAsync(PaginationParams @params);

    public Task<CourseViewModel> GetByIdAsync(long CourseId);

    public Task<bool> UpdateAsync(long CourseId, CourseUpdateDto dto);
}
