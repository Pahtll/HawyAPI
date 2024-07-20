using Hawy.Domain.Enums;
using Hawy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hawy.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    private const ushort UsernameMaxLength = 35;
    private const ushort EmailMaxLength = 60;
    
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .HasMaxLength(UsernameMaxLength)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(EmailMaxLength)
            .IsRequired();

        builder.Property(u => u.Role)
            .HasDefaultValue(UserRole.User)
            .IsRequired();

        builder.Property(u => u.RegisterDate)
            .IsRequired();

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.HasMany(u => u.Cart)
            .WithOne();
    }
}