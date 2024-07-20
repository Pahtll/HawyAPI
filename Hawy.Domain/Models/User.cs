using Hawy.Domain.Enums;

namespace Hawy.Domain.Models;

public class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    
    public UserRole Role { get; set; }

    public List<Product> Cart { get; set; } = [];
    
    public DateTime RegisterDate { get; set; }
}