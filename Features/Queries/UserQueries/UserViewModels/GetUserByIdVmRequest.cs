using GreenMarket.API.Extensions.PatternResultExtensions;
using MediatR;

namespace GreenMarket.Features.Queries.UserQueries.UserViewModels;
public record GetUserByIdVmRequest(int Id) : IRequest<Result<GetUserVm>>;