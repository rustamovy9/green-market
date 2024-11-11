using GreenMarket.Enums;
using GreenMarket.Features.Commands.TransactionHistoryCommands.TransactionHistoryCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.TransactionHistoryQueries.TransactionHistoryViewModels;

namespace GreenMarket.API.Extensions.Mappers;

public static class TransactionHistoryMappingExtensions
{
    public static GetTransactionHistoryVm ToReadInfo(this TransactionHistory transactionHistory)
    {
        return new()
        {
            Id = transactionHistory.Id,
            TransactionHistoryBaseInfo = new()
            {
                UserId = transactionHistory.UserId,
                ProductId = transactionHistory.ProductId,
                TransactionDate = transactionHistory.TransactionDate,
                TotalAmount = transactionHistory.TotalAmount,
                Status = Status.Completed
            }
        };
    }

    public static TransactionHistory ToTransactionHistory(this CreateTransactionHistoryRequest createInfo)
    {
        return new()
        {
            UserId = createInfo.TransactionHistoryBaseInfo.UserId,
            ProductId = createInfo.TransactionHistoryBaseInfo.ProductId,
            TotalAmount = createInfo.TransactionHistoryBaseInfo.TotalAmount,
            Status = Status.Pending
        };
    }

    public static TransactionHistory ToUpdate(this TransactionHistory transactionHistory ,UpdateTransactionHistoryRequest updateInfo)
    {
        transactionHistory.TotalAmount = updateInfo.TransactionHistoryBaseInfo.TotalAmount;
        transactionHistory.TransactionDate = DateTime.UtcNow;
        transactionHistory.Status = Status.Processing;
        transactionHistory.Version++;
        transactionHistory.UpdatedAt = DateTime.UtcNow;
        return transactionHistory;
    }

    public static TransactionHistory ToDeleted(this TransactionHistory transactionHistory)
    {
        transactionHistory.Status = Status.Cancelled;
        transactionHistory.IsDeleted = true;
        transactionHistory.DeletedAt = DateTime.UtcNow;
        transactionHistory.UpdatedAt = DateTime.UtcNow;
        transactionHistory.Version++;
        return transactionHistory;
    }
}