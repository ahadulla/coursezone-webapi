using CourseZone.DataAccsess.Interfaces.Stars;
using CourseZone.Domain.Entites.Stars;
using CourseZone.Service.Interfaces.Stars;

namespace CourseZone.Service.Services.Stars;

public class StarService : IStarService
{
    private IStarRepository _repository;

    public StarService(IStarRepository starRepository)
    {
        this._repository = starRepository;
    }
    public async Task<bool> CreateAsync(Star dto)
    {
        var result = await _repository.CreateAsync(dto);
        return result > 0;
    }
}
