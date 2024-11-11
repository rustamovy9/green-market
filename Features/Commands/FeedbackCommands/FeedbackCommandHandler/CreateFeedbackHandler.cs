using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.FeedbackCommands.FeedbackCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.FeedbackCommands.FeedbackCommandHandler;

public sealed class CreateFeedbackHandler(IUnitOfWork<Feedback> unitOfWork) : IRequestHandler<CreateFeedbackRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateFeedbackRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<Feedback> repository = unitOfWork.FeedbackAddRepository;
        

        await repository.AddAsync(request.ToFeedback());
        int res = await unitOfWork.Complete();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops...!!! Data not saved🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}