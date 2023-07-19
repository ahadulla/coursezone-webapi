using CourseZone.Service.Interfaces.Common;
using CourseZone.DataAccsess.Interfaces.Courses;
using CourseZone.DataAccsess.Utils;
using CourseZone.DataAccsess.ViewModels.Courses;
using CourseZone.Domain.Entites.Courses;
using CourseZone.Domain.Exceptions.Courses;
using CourseZone.Domain.Exceptions.Files;
using CourseZone.Service.Common.Helpers;
using CourseZone.Service.Dtos.Categories;
using CourseZone.Service.Dtos.Courses;
using CourseZone.Service.Interfaces.Courses;

namespace CourseZone.Service.Services.Courses;

public class CourseTypeService : ICourseTypeService
{
    private readonly ICourseTypeRepository _repository;
    private readonly IFileService _fileService;
    public CourseTypeService(ICourseTypeRepository courseTypeRepository,
        IFileService fileService)
    {
        this._repository = courseTypeRepository;
        this._fileService = fileService;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();


    public async Task<bool> CreateAsync(CourseTypeCreateDto dto)
    {
        string imagepath = await _fileService.UploadImageAsync(dto.Image);
        CourseType courseType = new CourseType()
        {
            ImagePath = imagepath,
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(courseType);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long TypeId)
    {
        var courseType = await _repository.GetByIdAsync(TypeId);
        if (courseType is null) throw new CourseTypeNotFoundException();

        var result = await _fileService.DeleteImageAsync(courseType.ImagePath);
        if (result == false) throw new ImageNotFoundException();

        var dbResult = await _repository.DeleteAsync(TypeId);
        return dbResult > 0;
    }

    public async Task<IList<CourseType>> GetAllAsync(PaginationParams @params)
    {
        var courseTypes = await _repository.GetAllAsync(@params);
        return courseTypes;
    }

    public async Task<CourseType> GetByIdAsync(long TypeId)
    {
        var courseType = await _repository.GetByIdAsync(TypeId);
        if (courseType is null) throw new CourseTypeNotFoundException();
        else return courseType;
    }

    public async Task<bool> UpdateAsync(long TypeId, CourseTypeUpdateDto dto)
    {
        var courseType = await _repository.GetByIdAsync(TypeId);
        if (courseType is null) throw new CourseTypeNotFoundException();

        courseType.Name = dto.Name;
        courseType.Description = dto.Description;

        if (dto.Image is not null)
        {
            var deleteResult = await _fileService.DeleteImageAsync(courseType.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            string newImagePath = await _fileService.UploadImageAsync(dto.Image);

            courseType.ImagePath = newImagePath;
        }

        courseType.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(TypeId, courseType);
        return dbResult > 0;
    }
}
