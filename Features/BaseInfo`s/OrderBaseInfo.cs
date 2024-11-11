using GreenMarket.Enums;

namespace GreenMarket.Features.BaseInfo_s;

public readonly record struct OrderBaseInfo(
    int UserId,
    DateTime OrderDate,
    Status Status,
    decimal TotalAmount);