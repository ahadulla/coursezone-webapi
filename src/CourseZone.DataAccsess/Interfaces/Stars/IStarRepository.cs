using CourseZone.Domain.Entites.Stars;

namespace CourseZone.DataAccsess.Interfaces.Stars;

public interface IStarRepository
{ 
    public Task<int> CreateAsync(Star entity);
}
