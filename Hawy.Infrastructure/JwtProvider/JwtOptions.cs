namespace Hawy.Infrastructure.JwtProvider;

public class JwtOptions
{
    public string SecretKey { get; set; } = string.Empty;
    
    public int ExpiresHours { get; set; }
}