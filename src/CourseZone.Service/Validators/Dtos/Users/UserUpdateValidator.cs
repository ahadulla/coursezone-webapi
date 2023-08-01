using CourseZone.Service.Dtos.Users;
using FluentValidation;

namespace CourseZone.Service.Validators.Dtos.Users;

public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateValidator()
    {
        RuleFor(dto => dto.FirstName).NotNull().NotEmpty().WithMessage("FirstName field is required!");
        RuleFor(dto => dto.LastName).NotNull().NotEmpty().WithMessage("FirstName field is required!");
        RuleFor(dto => dto.PhoneNumber).NotNull().NotEmpty().WithMessage("FirstName field is required!");
        RuleFor(dto => dto.PhoneNumber).Must(phone => PhoneNumberValidator.IsValid(phone))
                 .WithMessage("PhoneNumber addres is invalid!");

    }
}
