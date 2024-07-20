using Hawy.Domain.Models;
using Hawy.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hawy.Persistence.Repositories;

public class ProductRepository(HawyDbContext context) : IProductRepository
{
    private readonly HawyDbContext _context = context;

    public async Task<List<Product>> GetAll()
    {
        return await _context.Products
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Product> GetByTitle(string title)
    {
        return await _context.Products
                   .AsNoTracking()
                   .FirstOrDefaultAsync(p => p.Title == title)
               ?? throw new ArgumentException("Product with this title not found");
    }

    public async Task<Product> GetById(Guid id)
    {
        return await _context.Products
                   .AsNoTracking()
                   .FirstOrDefaultAsync(p => p.Id == id)
               ?? throw new ArgumentException("Product with this id not found");
    }

    public async Task<Guid> Create(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return product.Id;
    }

    public async Task<Guid> Update(Product product)
    {
        await _context.Products
            .ExecuteUpdateAsync(pp =>
                pp.SetProperty(p => p.Title, product.Title)
                    .SetProperty(p => p.Categories, product.Categories)
                    .SetProperty(p => p.Price, product.Price));

        return product.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Products
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}