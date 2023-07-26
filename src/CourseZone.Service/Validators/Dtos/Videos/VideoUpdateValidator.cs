using CourseZone.Service.Common.Helpers;
using CourseZone.Service.Dtos.Videos;
using FluentValidation;

namespace CourseZone.Service.Validators.Dtos.Videos;

public class VideoUpdateValidator : AbstractValidator<VideoUpdateDto>
{
    public VideoUpdateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters");

        When(dto => dto.Image is not null, () =>
        {
            int maxImageSizeMB = 5;
            RuleFor(dto => dto.Image!.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.Image!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });

        When(dto => dto.Video is not null, () =>
        {
            int maxVideoSizeMB = 300;
            RuleFor(dto => dto.Video!.Length).LessThan(maxVideoSizeMB * 1024 * 1024 + 1).WithMessage($"Video size must be less than {maxVideoSizeMB} MB");
            RuleFor(dto => dto.Video!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetVideoExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not video file");
        });
    }
}
