using GreenMarket.API.Extensions.PatternResultExtensions;
using MediatR;

namespace GreenMarket.Features.Queries.ProductCategoryQueries.ProductCategoryViewModels;
public record GetProductCategoryByIdVmRequest(int Id) : IRequest<Result<GetProductCategoryVm>>;