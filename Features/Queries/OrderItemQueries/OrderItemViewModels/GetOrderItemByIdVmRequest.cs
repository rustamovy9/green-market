using GreenMarket.API.Extensions.PatternResultExtensions;
using MediatR;

namespace GreenMarket.Features.Queries.OrderItemQueries.OrderItemViewModels;
public record GetOrderItemByIdVmRequest(int Id) : IRequest<Result<GetOrderItemVm>>;