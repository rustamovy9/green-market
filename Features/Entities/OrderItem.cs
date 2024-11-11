namespace GreenMarket.Features.Entities;

public sealed class OrderItem : BaseEntity
{
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; } 
    public decimal TotalPrice => Product.Price * Quantity; 
}