using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Data.Models;

namespace UserManagement.Data.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.ConfigureBaseEntity();

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasColumnType("nvarchar(100)");

            builder.Property(s => s.Surname)
                   .IsRequired()
                   .HasColumnType("nvarchar(100)");

            builder.Property(s => s.Email)
                   .IsRequired()
                   .HasColumnType("nvarchar(100)");

            builder.Property(s => s.IsActive)
                   .IsRequired()
                   .HasColumnType("bit");

            builder.Property(s => s.DateOfBirth)
                   .IsRequired()
                   .HasColumnType("datetime");
        }
    }
}
