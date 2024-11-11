using GreenMarket.API.Extensions.PatternResultExtensions;
using MediatR;

namespace GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandRequest;

public readonly record struct DeleteOrderItemRequest(int Id) : IRequest<BaseResult>;