namespace UserManagment.Data.Models;

public abstract class BaseModel
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? Modified { get; set; }
}
