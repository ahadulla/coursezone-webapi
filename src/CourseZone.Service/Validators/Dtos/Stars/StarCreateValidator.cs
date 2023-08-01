using CourseZone.Service.Dtos.Stars;
using FluentValidation;

namespace CourseZone.Service.Validators.Dtos.Stars;

public class StarCreateValidator : AbstractValidator<StarCreateDto>
{
    public StarCreateValidator()
    {
        RuleFor(dto => dto.CourseId).NotNull().NotEmpty().WithMessage("CourseId field is required!");
        RuleFor(dto => dto.StarCount).NotNull().NotEmpty().WithMessage("StarCount field is required!");
        RuleFor(dto => dto.StarCount).GreaterThan(0).WithMessage("StarCount must be greater than 0!");
    }
}
