using Hawy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hawy.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    private const ushort TitleMaxLength = 100;
    
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(p => p.Id);

        builder.Property(p => p.Title)
            .HasMaxLength(TitleMaxLength)
            .IsRequired();

        builder.Property(p => p.Price)
            .IsRequired();

        builder.HasMany(p => p.Categories)
            .WithMany();
    }
}