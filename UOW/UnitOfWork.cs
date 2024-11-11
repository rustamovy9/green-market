using GreenMarket.Data;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;

namespace GreenMarket.UOW;

public class UnitOfWork<T> : IUnitOfWork<T> where T : BaseEntity
{
    private readonly AppCommandDbContext _appCommand;
    private readonly AppQueryDbContext _queryContext;
    
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

    public UnitOfWork(
            AppCommandDbContext appCommand,
            AppQueryDbContext queryContext,
            
            IGenericUpdateRepository<User> userUpdateRepository,
            IGenericDeleteRepository<User> userDeleteRepository, 
            IGenericFindRepository<User> userFindRepository,
            IGenericAddRepository<User> userAddRepository,
                      
            IGenericUpdateRepository<TransactionHistory> transactionHistoryUpdateRepository,
            IGenericDeleteRepository<TransactionHistory> transactionHistoryDeleteRepository,
            IGenericFindRepository<TransactionHistory> transactionHistoryFindRepository,
            IGenericAddRepository<TransactionHistory> transactionHistoryAddRepository,
                      
            IGenericUpdateRepository<Feedback> feedbackUpdateRepository,
            IGenericDeleteRepository<Feedback> feedbackDeleteRepository,
            IGenericFindRepository<Feedback> feedbackFindRepository,
            IGenericAddRepository<Feedback> feedbackAddRepository,
            
           IGenericUpdateRepository<Order> orderRequestUpdateRepository,
            IGenericDeleteRepository<Order> orderRequestDeleteRepository, 
            IGenericFindRepository<Order> orderRequestFindRepository, 
            IGenericAddRepository<Order> orderRequestAddRepository,
            
            IGenericUpdateRepository<OrderItem> orderItemUpdateRepository,
            IGenericDeleteRepository<OrderItem> orderItemDeleteRepository,
            IGenericFindRepository<OrderItem> orderItemFindRepository,
            IGenericAddRepository<OrderItem> orderItemAddRepository,
            
            IGenericUpdateRepository<Product> productUpdateRepository,
            IGenericDeleteRepository<Product> productDeleteRepository,
            IGenericFindRepository<Product> productFindRepository,
            IGenericAddRepository<Product> productAddRepository,
            
            IGenericUpdateRepository<ProductCategory> productCategoryUpdateRepository,
            IGenericDeleteRepository<ProductCategory> productCategoryDeleteRepository,
            IGenericFindRepository<ProductCategory> productCategoryFindRepository,
            IGenericAddRepository<ProductCategory> productCategoryAddRepository)
    {
        _appCommand = appCommand;
        _queryContext = queryContext;

        UserUpdateRepository = userUpdateRepository;
        UserDeleteRepository = userDeleteRepository;
        UserFindRepository = userFindRepository;
        UserAddRepository = userAddRepository;

        TransactionHistoryUpdateRepository = transactionHistoryUpdateRepository;
        TransactionHistoryDeleteRepository = transactionHistoryDeleteRepository;
        TransactionHistoryFindRepository = transactionHistoryFindRepository;
        TransactionHistoryAddRepository = transactionHistoryAddRepository;
        
        FeedbackUpdateRepository = feedbackUpdateRepository;
        FeedbackDeleteRepository = feedbackDeleteRepository;
        FeedbackFindRepository = feedbackFindRepository;
        FeedbackAddRepository = feedbackAddRepository;
        
        OrderUpdateRepository = orderRequestUpdateRepository;
        OrderDeleteRepository = orderRequestDeleteRepository;
        OrderFindRepository = orderRequestFindRepository;
        OrderAddRepository = orderRequestAddRepository;
        
        OrderItemUpdateRepository = orderItemUpdateRepository;
        OrderItemDeleteRepository = orderItemDeleteRepository;
        OrderItemFindRepository = orderItemFindRepository;
        OrderItemAddRepository = orderItemAddRepository;
        
        ProductUpdateRepository = productUpdateRepository;
        ProductDeleteRepository = productDeleteRepository;
        ProductFindRepository = productFindRepository;
        ProductAddRepository = productAddRepository;
        
        ProductCategoryUpdateRepository = productCategoryUpdateRepository;
        ProductCategoryDeleteRepository = productCategoryDeleteRepository;
        ProductCategoryFindRepository = productCategoryFindRepository;
        ProductCategoryAddRepository = productCategoryAddRepository; 
    }

    public async Task<int> Complete()
    {
        return await _appCommand.SaveChangesAsync();
    }

    public void Dispose()
    {
        _appCommand.Dispose();
        _queryContext.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _appCommand.DisposeAsync();
        await _queryContext.DisposeAsync();
    }
}
