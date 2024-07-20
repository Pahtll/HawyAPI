namespace Hawy.Domain.Models;

public class Product
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    
    public double Price { get; set; }

    public List<Category> Categories { get; set; } = [];
}