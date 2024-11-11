using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.TransactionHistoryCommands.TransactionHistoryCommandRequest;
using GreenMarket.Features.Commands.UserCommands.UserCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.TransactionHistoryCommands.TransactionHistoryCommandHandler;

public class DeleteTransactionHistoryHandler(IUnitOfWork<TransactionHistory> unitOfWork) : IRequestHandler<DeleteTransactionHistoryRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteTransactionHistoryRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<TransactionHistory> repository = unitOfWork.TransactionHistoryDeleteRepository;
        IGenericFindRepository<TransactionHistory> findRepository = unitOfWork.TransactionHistoryFindRepository;

        TransactionHistory? transactionHistory = await findRepository.GetByIdAsync(request.Id);
        if(transactionHistory is null)
            return BaseResult.Failure(Error.NotFound("Oooops...!!! Data not found🤷‍♂️🤷‍♂️"));

        await repository.RemoveAsync(transactionHistory.ToDeleted());
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops! Data is not deleted🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}