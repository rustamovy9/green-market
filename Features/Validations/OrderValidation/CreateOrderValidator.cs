using FluentValidation;
using GreenMarket.Features.Commands.OrderCommands.OrderCommandRequest;

namespace GreenMarket.Features.Validations.OrderValidation;

public sealed class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderValidator()
    {
        RuleFor(f => f.OrderBaseInfo.UserId)
           .NotEmpty().WithMessage("UserId is required.");
        
        RuleFor(f => f.OrderBaseInfo.Status)
           .IsInEnum().WithMessage("Status is enum.");
    }
}