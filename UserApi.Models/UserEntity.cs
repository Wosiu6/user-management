using System.ComponentModel.DataAnnotations;

namespace UserManagment.UserApi.Models;

public class UserEntity : BaseEntity
{
    [Required]
    [MaxLength(255)]
    [MinLength(1)]
    public string? Name { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(1)]
    public string? Surname { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public bool IsActive { get; set; }

    [Required]
    public DateTime? DateOfBirth { get; set; }
}
