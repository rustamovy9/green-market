using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using MediatR;

namespace GreenMarket.Features.Commands.ProductCommands.ProductCommandRequest;

public readonly record struct CreateProductRequest(
    ProductBaseInfo ProductBaseInfo) : IRequest<BaseResult>;