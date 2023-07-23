using CourseZone.Service.Dtos.Auth;
using CourseZone.Service.Validators;
using FluentValidation;

namespace AgileShop.Service.Validators.Dtos.Auth;

public class LoginValidator : AbstractValidator<LoginDto>
{
	public LoginValidator()
	{
        RuleFor(dto => dto.Email).Must(email => EmailValidator.IsValid(email))
            .WithMessage("Phone number is invalid! ex: +998xxYYYAABB");

        RuleFor(dto => dto.Password).Must(password => PasswordValidator.IsStrongPassword(password).IsValid)
            .WithMessage("Password is not strong password!");
    }
}
