using Hawy.Domain.Models;

namespace Hawy.Persistence.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAll();
    Task<Product> GetByTitle(string title);
    Task<Product> GetById(Guid id);
    Task<Guid> Create(Product product);
    Task<Guid> Update(Product product);
    Task<Guid> Delete(Guid id);
}