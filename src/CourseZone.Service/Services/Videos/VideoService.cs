using CourseZone.DataAccsess.Interfaces.Videos;
using CourseZone.DataAccsess.Utils;
using CourseZone.Domain.Entites.Courses;
using CourseZone.Domain.Entites.Videas;
using CourseZone.Domain.Exceptions.Files;
using CourseZone.Domain.Exceptions.Videos;
using CourseZone.Service.Common.Helpers;
using CourseZone.Service.Dtos.Videos;
using CourseZone.Service.Interfaces.Common;
using CourseZone.Service.Interfaces.Videos;
using CourseZone.Service.Services.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace CourseZone.Service.Services.Videos;

public class VideoService : IVideoService
{
    private IVideoRepository _repository;
    private IVideoProtsesService _videoService;
    private IPaginator _paginator;
    private IFileService _fileService;

    public VideoService(IVideoRepository videoRepository,
        IVideoProtsesService videoProtsesService, IPaginator paginator,
        IFileService fileService)
    {
        this._repository = videoRepository;
        this._videoService = videoProtsesService;
        this._paginator = paginator;
        this._fileService = fileService;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(VideoCreateDto dto)
    {
        string videoPath = await _videoService.VideoUploadAsync(dto.Video)!;
        string imagePath = await _fileService.UploadImageAsync(dto.Image);
        var video = new Video
        {
            CourseId = dto.CourseId,
            Name = dto.Name,
            Description = dto.Description,
            VideoPath = videoPath!,
            ImagePath = imagePath,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
        };
        var result = await _repository.CreateAsync(video);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long videoId)
    {
        var video = await _repository.GetByIdAsync(videoId);
        if (video is null) throw new VideoNotFoundException();

        var result = await _videoService.VideoDeleteAsync(video.VideoPath);
        if (result == false) throw new VideoNotFoundException();

        result = await _fileService.DeleteImageAsync(video.ImagePath);
        if (result == false) throw new ImageNotFoundException();

        var dbResult = await _repository.DeleteAsync(videoId);
        return dbResult > 0;
    }

    public async Task<IList<Video>> GetAllAsync(PaginationParams @params)
    {
        var videos = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return videos;
    }

    public async Task<Video> GetByIdAsync(long videoId)
    {
        var video = await _repository.GetByIdAsync(videoId);
        if(video is null) throw new VideoNotFoundException();
        return video;
    }

    public async Task<bool> UpdateAsync(long videoId, VideoUpdateDto dto)
    {
        var video = await _repository.GetByIdAsync(videoId);
        if (video is null) throw new VideoNotFoundException();

        video.Name = dto.Name;
        video.Description = dto.Description;

        if (dto.Video is not null)
        {
            var deleteResult = await _videoService.VideoDeleteAsync(video.VideoPath);
            if (deleteResult is false) throw new ImageNotFoundException();

            string newImagePath = await _videoService.VideoUploadAsync(dto.Video);

            video.VideoPath = newImagePath;
        }
        if (dto.Image is not null)
        {
            var deleteResult = await _fileService.DeleteImageAsync(video.ImagePath);
            if (deleteResult is false) throw new ImageNotFoundException();

            string newImagePath = await _fileService.UploadImageAsync(dto.Image);

            video.ImagePath = newImagePath;
        }

        video.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(videoId, video);
        return dbResult > 0;
    }
}
