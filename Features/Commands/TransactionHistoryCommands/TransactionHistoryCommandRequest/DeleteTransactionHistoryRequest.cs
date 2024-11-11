using GreenMarket.API.Extensions.PatternResultExtensions;
using MediatR;

namespace GreenMarket.Features.Commands.TransactionHistoryCommands.TransactionHistoryCommandRequest;

public readonly record struct DeleteTransactionHistoryRequest(int Id) : IRequest<BaseResult>;