using GreenMarket.Enums;

namespace GreenMarket.Features.BaseInfo_s;

public readonly record struct UserBaseInfo(
    string FullName,
    string UserName,
    string Email,
    string Phone,
    string Address,
    UserRole Role);
