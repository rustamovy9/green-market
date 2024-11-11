using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.TransactionHistoryCommands.TransactionHistoryCommandRequest;
using GreenMarket.Features.Commands.UserCommands.UserCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.TransactionHistoryCommands.TransactionHistoryCommandHandler;

public sealed class CreateTransactionHistoryHandler(IUnitOfWork<User> unitOfWork) : IRequestHandler<CreateTransactionHistoryRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateTransactionHistoryRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<TransactionHistory> repository = unitOfWork.TransactionHistoryAddRepository;

        await repository.AddAsync(request.ToTransactionHistory());
        int res = await unitOfWork.Complete();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops...!!! Data not saved🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}