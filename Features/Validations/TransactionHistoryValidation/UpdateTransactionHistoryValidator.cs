using FluentValidation;
using GreenMarket.Features.Commands.TransactionHistoryCommands.TransactionHistoryCommandRequest;

namespace GreenMarket.Features.Validations.TransactionHistoryValidation;

public sealed class UpdateTransactionHistoryValidator : AbstractValidator<UpdateTransactionHistoryRequest>
{
    public UpdateTransactionHistoryValidator()
    {
        RuleFor(transaction => transaction.TransactionHistoryBaseInfo.UserId)
            .NotEmpty().WithMessage("UserId is required.");
       
        
        RuleFor(transaction => transaction.TransactionHistoryBaseInfo.TotalAmount)
            .NotEmpty().WithMessage("Amount is required.");
        
        RuleFor(transaction => transaction.TransactionHistoryBaseInfo.Status)
            .IsInEnum().WithMessage("Status is enum.");
    }
}