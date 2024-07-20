using Hawy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hawy.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    private const ushort TitleMaxLength = 20;
    
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(c => c.Id);

        builder.Property(c => c.Title)
            .HasMaxLength(TitleMaxLength)
            .IsRequired();
    }
}