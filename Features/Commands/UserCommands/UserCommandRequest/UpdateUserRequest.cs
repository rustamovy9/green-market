using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using MediatR;

namespace GreenMarket.Features.Commands.UserCommands.UserCommandRequest;

public readonly record struct UpdateUserRequest(
    int Id,
    UserBaseInfo UserBaseInfo) : IRequest<BaseResult>;