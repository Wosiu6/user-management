namespace UserManagement.Data.Models;

public class User : BaseModel
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required bool IsActive { get; set; }
    public required DateTime DateOfBirth { get; set; }
}
