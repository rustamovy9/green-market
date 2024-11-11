using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Data;
using GreenMarket.Features.Commands.TransactionHistoryCommands.TransactionHistoryCommandRequest;
using GreenMarket.Features.Commands.UserCommands.UserCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GreenMarket.Features.Commands.TransactionHistoryCommands.TransactionHistoryCommandHandler;

public class UpdateTransactionHistoryHandler(IUnitOfWork<TransactionHistory> unitOfWork) : IRequestHandler<UpdateTransactionHistoryRequest, BaseResult>
{
    public async Task<BaseResult> Handle(UpdateTransactionHistoryRequest request, CancellationToken cancellationToken)
    {
        IGenericUpdateRepository<TransactionHistory> repository = unitOfWork.TransactionHistoryUpdateRepository;
        IGenericFindRepository<TransactionHistory> findRepository = unitOfWork.TransactionHistoryFindRepository;
        
        TransactionHistory? transactionHistory = await findRepository.GetByIdAsync(request.Id);
        
        if (transactionHistory is null)
            return BaseResult.Failure(Error.NotFound("Oops! Data not found🤷‍♂️🤷‍♂️"));

        await repository.UpdateAsync(transactionHistory.ToUpdate(request));
        
        int res = await unitOfWork.Complete();
        
        return res > 0
            ? BaseResult.Success()  
            : BaseResult.Failure(Error.InternalServerError("Oops...!!! Data was not updated🤷‍♂️🤷‍♂️"));
    }
}
