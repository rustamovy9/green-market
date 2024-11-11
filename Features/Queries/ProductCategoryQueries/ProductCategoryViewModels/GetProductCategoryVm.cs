using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using GreenMarket.Filters;
using GreenMarket.Responses;
using MediatR;

namespace GreenMarket.Features.Queries.ProductCategoryQueries.ProductCategoryViewModels;

public readonly record struct GetProductCategoryVm(
    int Id,
    ProductCategoryBaseInfo ProductCategoryBaseInfo);
    
    
public record GetProductCategoryVmRequest(ProductCategoryFilter Filter) : IRequest<Result<PagedResponse<IEnumerable<GetProductCategoryVm>>>>;