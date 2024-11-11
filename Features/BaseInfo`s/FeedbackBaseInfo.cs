using GreenMarket.Enums;

namespace GreenMarket.Features.BaseInfo_s;

public readonly record struct FeedbackBaseInfo(
    int UserId,
    int? ProductId,
    int? OrderId,
    string Comment,
    Rating Rating);
