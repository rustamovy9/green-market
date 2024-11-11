using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Data;
using GreenMarket.Features.Commands.UserCommands.UserCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.FeedbackCommands.FeedbackCommandHandler;

public class DeleteFeedbackHandler(IUnitOfWork<Feedback> unitOfWork) : IRequestHandler<DeleteUserRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<Feedback> repository = unitOfWork.FeedbackDeleteRepository;
        IGenericFindRepository<Feedback> findRepository = unitOfWork.FeedbackFindRepository;

        Feedback? existingFeedback = await findRepository.GetByIdAsync(1);
        if(existingFeedback is null)
            return BaseResult.Failure(Error.NotFound("Oooops...!!! Data not found🤷‍♂️🤷‍♂️"));

        await repository.RemoveAsync(existingFeedback.ToDeleted());
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops! Data is not deleted🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}