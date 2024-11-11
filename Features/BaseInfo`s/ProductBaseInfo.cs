namespace GreenMarket.Features.BaseInfo_s;

public readonly record struct ProductBaseInfo(
    string Name,
    string Description,
    decimal Price,
    int Quantity,
    int FarmerId,
    int CategoryId,
    DateTime HarvestDate);