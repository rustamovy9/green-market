using GreenMarket.Enums;

namespace GreenMarket.Features.Entities;

public sealed class Feedback : BaseEntity
{
    public int UserId { get; set; } 
    public User User { get; set; } = null!;
    public int? ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int? OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public string? Comment { get; set; }
    public Rating Rating { get; set; }
}