using GreenMarket.Enums;

namespace GreenMarket.Features.Entities;

public sealed class User : BaseEntity
{
    public string FullName { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public UserRole Role { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    public ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();
}