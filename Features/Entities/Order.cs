using GreenMarket.Enums;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GreenMarket.Features.Entities;

public sealed class Order :BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public Status Status { get; set; } 
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>(); 
    public decimal TotalAmount { get; set; }
    public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}