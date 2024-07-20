using Hawy.Domain.Models;

namespace Hawy.Persistence.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User> GetById(Guid id);
    Task<User> GetByEmail(string email);
    Task<User> GetByUsername(string username);
    Task<Guid> CreateUser(User user);
    Task<Guid> UpdateUserData(User user);
    Task<Guid> ChangePassword(Guid id, string newPasswordHash);
    Task<Guid> ClearCart(Guid id);
    Task<Guid> RemoveItemFromCart(Guid userId, Guid productId);
    Task<Guid> DeleteUser(Guid id);
}