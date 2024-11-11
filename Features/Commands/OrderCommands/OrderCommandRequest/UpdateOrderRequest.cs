using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using GreenMarket.Features.Entities;
using MediatR;

namespace GreenMarket.Features.Commands.OrderCommands.OrderCommandRequest;

public readonly record struct UpdateOrderRequest(
    int Id,
    OrderBaseInfo OrderBaseInfo) : IRequest<BaseResult>;