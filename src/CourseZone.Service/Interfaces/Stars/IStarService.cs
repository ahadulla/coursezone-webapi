using CourseZone.Service.Dtos.Stars;

namespace CourseZone.Service.Interfaces.Stars;

public interface IStarService
{
    public Task<bool> CreateAsync(StarCreateDto dto);
}
