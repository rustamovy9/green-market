using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.FeedbackCommands.FeedbackCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.FeedbackCommands.FeedbackCommandHandler;

public class UpdateFeedbackHandler(IUnitOfWork<Feedback> unitOfWork) : IRequestHandler<UpdateFeedbackRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateFeedbackRequest request, CancellationToken cancellationToken)
    {
        IGenericUpdateRepository<Feedback> repository = unitOfWork.FeedbackUpdateRepository;
        IGenericFindRepository<Feedback> findRepository = unitOfWork.FeedbackFindRepository;
        
        Feedback? feedback = await findRepository.GetByIdAsync(request.Id);
        if(feedback is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));;

        
        await repository.UpdateAsync(feedback.ToUpdate(request));
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("oops...!!! Data is not updated🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}