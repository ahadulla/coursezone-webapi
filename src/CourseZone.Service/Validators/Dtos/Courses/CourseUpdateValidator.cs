﻿using CourseZone.Service.Common.Helpers;
using CourseZone.Service.Dtos.Courses;
using FluentValidation;

namespace CourseZone.Service.Validators.Dtos.Courses;

public class CourseUpdateValidator : AbstractValidator<CourseUpdateDto>
{
    public CourseUpdateValidator()
    {
        RuleFor(dto => dto.TypeId).NotNull().NotEmpty().WithMessage("TypeId field is required!");

        When(dto => dto.Image is not null, () =>
        {
            int maxImageSizeMB = 5;
            RuleFor(dto => dto.Image!.Length).LessThan(maxImageSizeMB * 1024 * 1024).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.Image!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}
