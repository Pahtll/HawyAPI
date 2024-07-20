using Hawy.Domain.Models;
using Hawy.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Hawy.Persistence;

public class HawyDbContext(DbContextOptions<HawyDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<Category> Categories { get; set; }
}