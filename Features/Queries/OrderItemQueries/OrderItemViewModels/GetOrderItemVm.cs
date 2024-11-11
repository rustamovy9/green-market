using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using GreenMarket.Filters;
using GreenMarket.Responses;
using MediatR;

namespace GreenMarket.Features.Queries.OrderItemQueries.OrderItemViewModels;

public readonly record struct GetOrderItemVm(
    int Id,
    OrderItemBaseInfo OrderItemBaseInfo,
    decimal TotalPrice);
    
    
public record GetOrderItemVmRequest(OrderItemFilter Filter) : IRequest<Result<PagedResponse<IEnumerable<GetOrderItemVm>>>>;