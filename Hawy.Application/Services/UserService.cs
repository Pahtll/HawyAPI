using Hawy.Domain.Enums;
using Hawy.Domain.Models;
using Hawy.Infrastructure.JwtProvider;
using Hawy.Infrastructure.PasswordHasher;
using Hawy.Persistence.Interfaces;

namespace Hawy.Application.Services;

public class UserService(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider)
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<List<User>> GetAll()
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> GetById(Guid id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<User> GetByUsername(string username)
    {
        return await _userRepository.GetByUsername(username);
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _userRepository.GetByEmail(email);
    }

    public async Task<Guid> CreateUser(
        string username,
        string email,
        string password)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = username,
            PasswordHash = _passwordHasher.Generate(password),
            Email = email,
            RegisterDate = DateTime.UtcNow
        };

        return await _userRepository.CreateUser(user);
    }

    public async Task<Guid> Update(
        Guid id,
        string username,
        string email,
        UserRole role)
    {
        var user = new User
        {
            Id = id,
            Username = username,
            Email = email,
            Role = role,
        };

        return await _userRepository.UpdateUserData(user);
    }
}