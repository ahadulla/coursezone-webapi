using CourseZone.Service.Common.Helpers;
using CourseZone.Service.Dtos.Videos;
using FluentValidation;

namespace CourseZone.Service.Validators.Dtos.Videos;

public class VideoCreateValidator : AbstractValidator<VideoCreateDto>
{
    public VideoCreateValidator()
    {
        RuleFor(dto => dto.CourseId).NotNull().NotEmpty().WithMessage("CourseId field is required!");

        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters");

        int maxImageSizeMB = 5;
        RuleFor(dto => dto.Image).NotEmpty().NotNull().WithMessage("Image field is required");
        RuleFor(dto => dto.Image.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
        RuleFor(dto => dto.Image.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
        }).WithMessage("This file type is not image file");

        int maxVideoSizeMB = 300;
        RuleFor(dto => dto.Video).NotEmpty().NotNull().WithMessage("Video field is required");
        RuleFor(dto => dto.Video.Length).LessThan(maxVideoSizeMB * 1024 * 1024 + 1).WithMessage($"Video size must be less than {maxVideoSizeMB} MB");
        RuleFor(dto => dto.Video.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelper.GetVideoExtensions().Contains(fileInfo.Extension);
        }).WithMessage("This file type is not video file");
    }
}
