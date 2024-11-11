using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using MediatR;

namespace GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandRequest;

public readonly record struct UpdateOrderItemRequest(
    int Id,
    OrderItemBaseInfo OrderItemBaseInfo) : IRequest<BaseResult>;