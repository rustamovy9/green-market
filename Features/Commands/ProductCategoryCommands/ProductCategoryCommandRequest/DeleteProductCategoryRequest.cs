using GreenMarket.API.Extensions.PatternResultExtensions;
using MediatR;

namespace GreenMarket.Features.Commands.ProductCategoryCommands.ProductCategoryCommandRequest;

public readonly record struct DeleteProductCategoryRequest(int Id) : IRequest<BaseResult>;