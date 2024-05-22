using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Data.Models;

namespace UserManagement.Data;

public static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<T> ConfigureBaseEntity<T>(this EntityTypeBuilder<T> builder) 
        where T : BaseModel
    {
        builder.HasKey(e => e.Id);

        builder.Property(s => s.Created)
            .HasColumnType("datetime2")
            .HasDefaultValueSql("getdate()");

        builder.Property(s => s.Modified)
            .HasColumnType("datetime2");

        return builder;
    }
}