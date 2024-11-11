using GreenMarket.API.Extensions.PatternResultExtensions;
using MediatR;

namespace GreenMarket.Features.Commands.OrderCommands.OrderCommandRequest;

public readonly record struct DeleteOrderRequest(int Id) : IRequest<BaseResult>;