using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using MediatR;

namespace GreenMarket.Features.Commands.TransactionHistoryCommands.TransactionHistoryCommandRequest;

public readonly record struct UpdateTransactionHistoryRequest(
    int Id,
    TransactionHistoryBaseInfo TransactionHistoryBaseInfo) : IRequest<BaseResult>;