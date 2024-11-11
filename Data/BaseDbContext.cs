using GreenMarket.API.Extensions.EFCore;
using GreenMarket.Features.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenMarket.Data;

public class BaseDbContext(DbContextOptions<BaseDbContext> options)  : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<TransactionHistory> TransactionHistories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        modelBuilder.FilterSoftDeletedProperties();
        base.OnModelCreating(modelBuilder);
    }
}