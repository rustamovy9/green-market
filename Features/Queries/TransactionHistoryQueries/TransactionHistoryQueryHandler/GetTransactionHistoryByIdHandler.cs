using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.TransactionHistoryQueries.TransactionHistoryViewModels;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Queries.TransactionHistoryQueries.TransactionHistoryQueryHandler;

public class GetTransactionHistoryByIdHandler(IUnitOfWork<TransactionHistory> unitOfWork) : IRequestHandler<GetTransactionHistoryByIdVmRequest,Result<GetTransactionHistoryVm>>
{
    public async Task<Result<GetTransactionHistoryVm>> Handle(GetTransactionHistoryByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<TransactionHistory>? repository = unitOfWork.TransactionHistoryFindRepository;
        TransactionHistory? transactionHistory = await repository.GetByIdAsync(request.Id);
        return transactionHistory is null
            ? Result<GetTransactionHistoryVm>.Failure(Error.NotFound())
            : Result<GetTransactionHistoryVm>.Success(transactionHistory.ToReadInfo());
    }


}