using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using GreenMarket.Filters;
using GreenMarket.Responses;
using MediatR;

namespace GreenMarket.Features.Queries.UserQueries.UserViewModels;

public readonly record struct GetUserVm(
    int Id,
    UserBaseInfo UserBaseInfo);
    
    
public record GetUserVmRequest(UserFilter Filter) : IRequest<Result<PagedResponse<IEnumerable<GetUserVm>>>>;