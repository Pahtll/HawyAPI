using Hawy.Domain.Models;

namespace Hawy.Infrastructure.JwtProvider;

public interface IJwtProvider
{
    string GenerateToken(User user);
}