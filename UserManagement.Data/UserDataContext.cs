using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Configurations;
using UserManagement.Data.Models;

public class UserDataContext : DbContext 
{
    public DbSet<User> Users { get; set; }

    public UserDataContext(DbContextOptions<UserDataContext> options) 
        : base(options) { }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new UserEntityConfiguration().Configure(modelBuilder.Entity<User>());
    }
}
