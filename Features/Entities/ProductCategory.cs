namespace GreenMarket.Features.Entities;

public sealed class ProductCategory : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = new List<Product>(); 
}