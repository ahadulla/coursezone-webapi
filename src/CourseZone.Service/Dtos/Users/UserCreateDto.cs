using System.ComponentModel.DataAnnotations;

namespace CourseZone.Service.Dtos.Users;

public class UserCreateDto
{
    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = String.Empty;

    public string AvatarPath { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = String.Empty;

    public string Salt { get; set; } = String.Empty;

}
