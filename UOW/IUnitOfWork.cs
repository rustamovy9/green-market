using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;

namespace GreenMarket.UOW;

public interface IUnitOfWork<T> : IDisposable,IAsyncDisposable where T : BaseEntity
{
    public IGenericUpdateRepository<User> UserUpdateRepository { get; }
    public IGenericDeleteRepository<User> UserDeleteRepository { get; }
    public IGenericFindRepository<User> UserFindRepository { get; }
    public IGenericAddRepository<User> UserAddRepository { get; }
    
    public IGenericUpdateRepository<TransactionHistory> TransactionHistoryUpdateRepository { get; }
    public IGenericDeleteRepository<TransactionHistory> TransactionHistoryDeleteRepository { get; }
    public IGenericFindRepository<TransactionHistory> TransactionHistoryFindRepository { get; }
    public IGenericAddRepository<TransactionHistory> TransactionHistoryAddRepository { get; }
    
    public IGenericUpdateRepository<Feedback> FeedbackUpdateRepository { get; }
    public IGenericDeleteRepository<Feedback> FeedbackDeleteRepository { get; }
    public IGenericFindRepository<Feedback> FeedbackFindRepository { get; }
    public IGenericAddRepository<Feedback> FeedbackAddRepository { get; }
    
    public IGenericUpdateRepository<Order> OrderUpdateRepository { get; }
    public IGenericDeleteRepository<Order> OrderDeleteRepository { get; }
    public IGenericFindRepository<Order> OrderFindRepository { get; }
    public IGenericAddRepository<Order> OrderAddRepository { get; }
    
    public IGenericUpdateRepository<OrderItem> OrderItemUpdateRepository { get; }
    public IGenericDeleteRepository<OrderItem> OrderItemDeleteRepository { get; }
    public IGenericFindRepository<OrderItem> OrderItemFindRepository { get; }
    public IGenericAddRepository<OrderItem> OrderItemAddRepository { get; }
    
    public IGenericUpdateRepository<Product> ProductUpdateRepository { get; }
    public IGenericDeleteRepository<Product> ProductDeleteRepository { get; }
    public IGenericFindRepository<Product> ProductFindRepository { get; }
    public IGenericAddRepository<Product> ProductAddRepository { get; }
    
    public IGenericUpdateRepository<ProductCategory> ProductCategoryUpdateRepository { get; }
    public IGenericDeleteRepository<ProductCategory> ProductCategoryDeleteRepository { get; }
    public IGenericFindRepository<ProductCategory> ProductCategoryFindRepository { get; }
    public IGenericAddRepository<ProductCategory> ProductCategoryAddRepository { get; }
 
    Task<int> Complete();
}