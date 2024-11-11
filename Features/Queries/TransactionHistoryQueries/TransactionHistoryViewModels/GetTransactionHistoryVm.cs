using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using GreenMarket.Filters;
using GreenMarket.Responses;
using MediatR;

namespace GreenMarket.Features.Queries.TransactionHistoryQueries.TransactionHistoryViewModels;

public readonly record struct GetTransactionHistoryVm(
    int Id,
    TransactionHistoryBaseInfo TransactionHistoryBaseInfo);
    
    
public record GetTransactionHistoryVmRequest(TransactionHistoryFilter Filter) : IRequest<Result<PagedResponse<IEnumerable<GetTransactionHistoryVm>>>>;