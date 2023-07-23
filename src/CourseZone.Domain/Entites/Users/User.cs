using CourseZone.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CourseZone.Domain.Entites.Users;

public class User : Auditable
{
    [MaxLength(50)]
    public string FirstName { get; set; } = String.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = String.Empty;

    public string Email { get; set; } = string.Empty;

    public bool EmailConfirmed { get; set; }

    [MaxLength(13)]
    public string PhoneNumber { get; set; } = String.Empty;

    public double Balance { get; set; }

    public string AvatarPath { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = String.Empty;

    public string Salt { get; set; } = String.Empty;

    public bool IsDetated { get; set; }

    public IdentityRole Role { get; set; }
}
