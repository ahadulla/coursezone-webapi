using CourseZone.DataAccsess.Interfaces.Stars;
using CourseZone.Domain.Entites.Stars;
using CourseZone.Service.Dtos.Stars;
using CourseZone.Service.Interfaces.Auth;
using CourseZone.Service.Interfaces.Stars;

namespace CourseZone.Service.Services.Stars;

public class StarService : IStarService
{
    private IStarRepository _repository;
    private IIdentityService _identity;

    public StarService(IStarRepository starRepository, IIdentityService identityService)
    {
        this._repository = starRepository;
        this._identity = identityService;
    }
    public async Task<bool> CreateAsync(StarCreateDto dto)
    {
        Star star = new Star();
        star.UserId = _identity.UserId;
        star.CourseId = dto.CourseId;
        star.StarCount = dto.StarCount;

        var result = await _repository.CreateAsync(star);
        return result > 0;
    }
}
