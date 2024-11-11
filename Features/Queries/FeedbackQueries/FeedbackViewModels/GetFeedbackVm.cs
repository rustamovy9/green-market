using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using GreenMarket.Filters;
using GreenMarket.Responses;
using MediatR;

namespace GreenMarket.Features.Queries.FeedbackQueries.FeedbackViewModels;

public readonly record struct GetFeedbackVm(
    int Id,
    FeedbackBaseInfo FeedbackBaseInfo);
    
    
public record GetFeedbackVmRequest(FeedbackFilter Filter) : IRequest<Result<PagedResponse<IEnumerable<GetFeedbackVm>>>>;