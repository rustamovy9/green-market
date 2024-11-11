using GreenMarket.Enums;

namespace GreenMarket.Features.BaseInfo_s;

public readonly record struct TransactionHistoryBaseInfo(
    int UserId,
    DateTime TransactionDate,
    int ProductId,
    decimal TotalAmount,
    Status Status);