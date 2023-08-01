using CourseZone.Service.Dtos.Order;
using FluentValidation;

namespace CourseZone.Service.Validators.Dtos.Order;

public class OrderCreateValidator : AbstractValidator<OrderCreateDto>
{
    public OrderCreateValidator()
    {
        RuleFor(dto => dto.CourseId).NotNull().NotEmpty().WithMessage("CourseId field is required!");
    }
}
