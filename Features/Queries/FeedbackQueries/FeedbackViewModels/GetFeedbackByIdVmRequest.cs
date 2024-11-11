using GreenMarket.API.Extensions.PatternResultExtensions;
using MediatR;

namespace GreenMarket.Features.Queries.FeedbackQueries.FeedbackViewModels;
public record GetFeedbackByIdVmRequest(int Id) : IRequest<Result<GetFeedbackVm>>;