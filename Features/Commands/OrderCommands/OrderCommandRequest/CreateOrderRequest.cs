using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using MediatR;

namespace GreenMarket.Features.Commands.OrderCommands.OrderCommandRequest;

public readonly record struct CreateOrderRequest(
    OrderBaseInfo OrderBaseInfo) : IRequest<BaseResult>;