using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.FeedbackQueries.FeedbackViewModels;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Queries.FeedbackQueries.FeedbackQueryHandler;

public class GetFeedbackByIdHandler(IUnitOfWork<Feedback> unitOfWork) : IRequestHandler<GetFeedbackByIdVmRequest,Result<GetFeedbackVm>>
{
    public async Task<Result<GetFeedbackVm>> Handle(GetFeedbackByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Feedback>? repository = unitOfWork.FeedbackFindRepository;
        Feedback? feedback = await repository.GetByIdAsync(request.Id);

        return feedback is null
            ? Result<GetFeedbackVm>.Failure(Error.NotFound())
            : Result<GetFeedbackVm>.Success(feedback.ToReadInfo());
    }
}