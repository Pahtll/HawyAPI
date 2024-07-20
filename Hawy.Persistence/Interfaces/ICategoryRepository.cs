using Hawy.Domain.Models;

namespace Hawy.Persistence.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAll();
    Task<Category> GetById(Guid id);
    Task<Guid> Create(Category category);
    Task<Guid> Delete(Guid id);
}