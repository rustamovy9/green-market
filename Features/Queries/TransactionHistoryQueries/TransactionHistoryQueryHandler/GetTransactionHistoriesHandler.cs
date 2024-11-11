using System.Linq.Expressions;
using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.TransactionHistoryQueries.TransactionHistoryViewModels;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.Responses;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Queries.TransactionHistoryQueries.TransactionHistoryQueryHandler;

public sealed class GetTransactionHistoriesHandler(IUnitOfWork<User> unitOfWork) : IRequestHandler<GetTransactionHistoryVmRequest, Result<PagedResponse<IEnumerable<GetTransactionHistoryVm>>>>
{

    public async Task<Result<PagedResponse<IEnumerable<GetTransactionHistoryVm>>>> Handle(GetTransactionHistoryVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<TransactionHistory> repository = unitOfWork.TransactionHistoryFindRepository;

        Expression<Func<TransactionHistory, bool>> filterExpression = t =>
            (request.Filter.StartDate == null || t.TransactionDate >= request.Filter.StartDate) &&
             (request.Filter.EndDate == null || t.TransactionDate <= request.Filter.EndDate)  &&
             (request.Filter.Status == null || t.Status == request.Filter.Status);

        IEnumerable<TransactionHistory> query = (await repository
            .FindAsync(filterExpression)).ToList(); 
        
        int totalRecords =  query.Count();
        
        IEnumerable<GetTransactionHistoryVm> result =  query
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize)
            .Select(x => x.ToReadInfo()).ToList();
        

        PagedResponse<IEnumerable<GetTransactionHistoryVm>> response = PagedResponse<IEnumerable<GetTransactionHistoryVm>>.Create(
            request.Filter.PageNumber, 
            request.Filter.PageSize, 
            totalRecords, 
            result
        );

        return Result<PagedResponse<IEnumerable<GetTransactionHistoryVm>>>.Success(response);
    }
}