using CourseZone.DataAccsess.Interfaces.Courses;
using CourseZone.DataAccsess.Utils;
using CourseZone.DataAccsess.ViewModels.Courses;
using CourseZone.Domain.Entites.Courses;
using CourseZone.Domain.Exceptions.Courses;
using CourseZone.Domain.Exceptions.Files;
using CourseZone.Service.Common.Helpers;
using CourseZone.Service.Dtos.Courses;
using CourseZone.Service.Interfaces.Common;
using CourseZone.Service.Interfaces.Courses;
using System;

namespace CourseZone.Service.Services.Courses;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repository;
    private readonly IFileService _fileService;
    private readonly IPaginator _paginator;

    public CourseService(ICourseRepository courseRepository,IFileService fileService, IPaginator paginator)
    {
        this._repository = courseRepository;
        this._fileService = fileService;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(CourseCreateDto dto)
    {
        string imagepath = await _fileService.UploadImageAsync(dto.Image);
        Course course = new Course()
        {
            Language = dto.Language,
            UserId = dto.UserId,
            CourseTypeId = dto.TypeId,
            Name = dto.Name,
            Price = dto.Price,
            Description = dto.Description,
            ImagePath = imagepath,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(course);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long CourseId)
    {
        var course = await _repository.GetByIdAsyncSpecial(CourseId);
        if (course is null) throw new CourseNotFoundException();

        var result = await _fileService.DeleteImageAsync(course.ImagePath);
        if (result == false) throw new ImageNotFoundException();

        var dbResult = await _repository.DeleteAsync(CourseId);
        return dbResult > 0;
    }

    public async Task<IList<CourseViewModel>> GetAllAsync(PaginationParams @params)
    {
        var courses = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return courses;
    }

    public async Task<CourseViewModel> GetByIdAsync(long CourseId)
    {
        var courses = await _repository.GetByIdAsync(CourseId);
        if (courses is null) throw new CourseNotFoundException();
        else return courses;
    }

    public async Task<bool> UpdateAsync(long CourseId, CourseUpdateDto dto)
    {
        var course = await _repository.GetByIdAsyncSpecial(CourseId);
        if(course is null) throw new CourseNotFoundException();

        course.Language = dto.Language;
        course.CourseTypeId = dto.TypeId;
        course.Name = dto.Name;
        course.Price = dto.Price;
        course.Description = dto.Description;

        if(dto.Image is not null)
        {
            var deleteResult = await _fileService.DeleteImageAsync(course.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            string newImagePath = await _fileService.UploadImageAsync(dto.Image);

            course.ImagePath = newImagePath;
        }
        course.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(CourseId, course);
        return dbResult > 0;

    }
}
