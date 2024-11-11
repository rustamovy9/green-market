using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using GreenMarket.Filters;
using GreenMarket.Responses;
using MediatR;

namespace GreenMarket.Features.Queries.ProductQueries.ProductViewModels;

public readonly record struct GetProductVm(
    int Id,
    ProductBaseInfo ProductBaseInfo);
    
    
public record GetProductVmRequest(ProductFilter Filter) : IRequest<Result<PagedResponse<IEnumerable<GetProductVm>>>>;