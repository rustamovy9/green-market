using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using GreenMarket.Filters;
using GreenMarket.Responses;
using MediatR;

namespace GreenMarket.Features.Queries.OrderQueries.OrderViewModels;

public readonly record struct GetOrderVm(
    int Id,
    OrderBaseInfo OrderBaseInfo);
    
    
public record GetOrderVmRequest(OrderFilter Filter) : IRequest<Result<PagedResponse<IEnumerable<GetOrderVm>>>>;