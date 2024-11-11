using GreenMarket.Enums;

namespace GreenMarket.Features.Entities;

public sealed class TransactionHistory : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; } 
    public Status Status { get; set; }
}