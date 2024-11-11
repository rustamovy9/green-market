namespace GreenMarket.Features.BaseInfo_s;

public readonly record struct OrderItemBaseInfo(
    int OrderId,
    int ProductId,
    int Quantity);