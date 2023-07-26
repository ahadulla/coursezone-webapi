using CourseZone.Domain.Entites.Stars;

namespace CourseZone.Service.Interfaces.Stars;

public interface IStarService
{
    public Task<bool> CreateAsync(Star dto);
}
