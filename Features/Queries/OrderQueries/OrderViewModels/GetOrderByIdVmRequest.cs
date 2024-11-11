using GreenMarket.API.Extensions.PatternResultExtensions;
using MediatR;

namespace GreenMarket.Features.Queries.OrderQueries.OrderViewModels;
public record GetOrderByIdVmRequest(int Id) : IRequest<Result<GetOrderVm>>;