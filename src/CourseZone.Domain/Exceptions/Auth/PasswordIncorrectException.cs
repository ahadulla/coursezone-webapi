using CourseZone.Domain.Exceptions;

namespace AgileShop.Domain.Exceptions.Auth;

public class PasswordIncorrectException : BadRequestException
{
	public PasswordIncorrectException()
	{
		TitleMessage = "Password is invalid!";
	}
}
