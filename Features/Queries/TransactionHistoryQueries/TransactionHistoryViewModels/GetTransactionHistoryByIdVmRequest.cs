using GreenMarket.API.Extensions.PatternResultExtensions;
using MediatR;

namespace GreenMarket.Features.Queries.TransactionHistoryQueries.TransactionHistoryViewModels;
public record GetTransactionHistoryByIdVmRequest(int Id) : IRequest<Result<GetTransactionHistoryVm>>;