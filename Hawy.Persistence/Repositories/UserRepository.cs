using Hawy.Domain.Models;
using Hawy.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hawy.Persistence.Repositories;

public class UserRepository(HawyDbContext context) : IUserRepository
{
    private readonly HawyDbContext _context = context;

    public async Task<List<User>> GetAll()
    {
        return await _context.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User> GetById(Guid id)
    {
        return await _context.Users
                   .AsNoTracking()
                   .FirstOrDefaultAsync(u => u.Id == id)
               ?? throw new ArgumentException("User with this ID not found");
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _context.Users
                   .AsNoTracking()
                   .FirstOrDefaultAsync(u => u.Email == email)
               ?? throw new ArgumentException("User with this email not found");
    }

    public async Task<User> GetByUsername(string username)
    {
        return await _context.Users
                   .AsNoTracking()
                   .FirstOrDefaultAsync(u => u.Username == username)
               ?? throw new ArgumentException("User with this username not foun");
    }

    public async Task<Guid> CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<Guid> UpdateUserData(User user)
    {
        await _context.Users
            .Where(u => u.Id == user.Id)
            .ExecuteUpdateAsync(
                up =>
                    up.SetProperty(u => u.Username, user.Username)
                        .SetProperty(u => u.Email, user.Email)
                        .SetProperty(u => u.Role, user.Role));

        return user.Id;
    }

    public async Task<Guid> ChangePassword(Guid id, string newPasswordHash)
    {
        await _context.Users
            .Where(u => u.Id == id)
            .ExecuteUpdateAsync(up =>
                up.SetProperty(u => u.PasswordHash, newPasswordHash));

        return id;
    }

    public async Task<Guid> ClearCart(Guid id)
    {
        var user = await GetById(id);
        
        user.Cart = [];

        await _context.SaveChangesAsync();

        return id;
    }

    public async Task<Guid> RemoveItemFromCart(Guid userId, Guid productId)
    {
        var user = await GetById(userId);
        
        user.Cart = user.Cart
            .Where(p => p.Id != productId)
            .ToList();

        await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<Guid> DeleteUser(Guid id)
    {
        await _context.Users
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}