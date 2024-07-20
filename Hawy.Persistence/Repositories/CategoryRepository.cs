using Hawy.Domain.Models;
using Hawy.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hawy.Persistence.Repositories;

public class CategoryRepository(HawyDbContext context) : ICategoryRepository
{
    private readonly HawyDbContext _context = context;

    public async Task<List<Category>> GetAll()
    {
        return await _context.Categories
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Category> GetById(Guid id)
    {
        return await _context.Categories
                   .AsNoTracking()
                   .FirstOrDefaultAsync(c => c.Id == id)
               ?? throw new ArgumentException("Category with this id not found");
    }

    public async Task<Guid> Create(Category category)
    {
        await _context.AddAsync(category);
        await _context.SaveChangesAsync();

        return category.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Categories
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}