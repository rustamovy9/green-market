namespace GreenMarket.Features.Entities;

public sealed class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int FarmerId { get; set; }
    public User Farmer { get; set; } = null!;
    public int CategoryId { get; set; }
    public ProductCategory Category { get; set; } = null!;
    public DateTime HarvestDate { get; set; }
    public ICollection<TransactionHistory> TransactionHistories { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}