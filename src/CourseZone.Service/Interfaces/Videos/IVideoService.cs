using CourseZone.DataAccsess.Utils;
using CourseZone.DataAccsess.ViewModels.Courses;
using CourseZone.Domain.Entites.Videas;
using CourseZone.Service.Dtos.Courses;
using CourseZone.Service.Dtos.Videos;
using Microsoft.AspNetCore.Http;

namespace CourseZone.Service.Interfaces.Videos;

public interface IVideoService
{
    public Task<bool> CreateAsync(VideoCreateDto dto);

    public Task<bool> DeleteAsync(long videoId);

    public Task<long> CountAsync();

    public Task<IList<Video>> GetAllAsync(PaginationParams @params);

    public Task<Video> GetByIdAsync(long videoId);

    public Task<bool> UpdateAsync(long videoId, VideoUpdateDto dto);
}
