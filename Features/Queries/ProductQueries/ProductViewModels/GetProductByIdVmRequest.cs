using GreenMarket.API.Extensions.PatternResultExtensions;
using MediatR;

namespace GreenMarket.Features.Queries.ProductQueries.ProductViewModels;
public record GetProductByIdVmRequest(int Id) : IRequest<Result<GetProductVm>>;