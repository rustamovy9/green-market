using GreenMarket.API.Extensions.PatternResultExtensions;
using MediatR;

namespace GreenMarket.Features.Commands.ProductCommands.ProductCommandRequest;

public readonly record struct DeleteProductRequest(int Id) : IRequest<BaseResult>;