using Microsoft.AspNetCore.Http;

namespace CourseZone.Service.Interfaces.Common;

public interface IVideoProtsesService
{

    public Task<string?> VideoUploadAsync(IFormFile video);

    public Task<bool> VideoDeleteAsync(string subPath);
}
