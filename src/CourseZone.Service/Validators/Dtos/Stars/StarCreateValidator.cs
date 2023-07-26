using CourseZone.Domain.Entites.Stars;
using FluentValidation;

namespace CourseZone.Service.Validators.Dtos.Stars;

public class StarCreateValidator : AbstractValidator<Star>
{
    public StarCreateValidator()
    {
        RuleFor(dto => dto.UserId).NotNull().NotEmpty().WithMessage("UserId field is required!");
        RuleFor(dto => dto.CourseId).NotNull().NotEmpty().WithMessage("CourseId field is required!");
        RuleFor(dto => dto.StarCount).NotNull().NotEmpty().WithMessage("StarCount field is required!");
    }
}
