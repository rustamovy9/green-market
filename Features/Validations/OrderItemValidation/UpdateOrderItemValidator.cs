using FluentValidation;
using GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandRequest;

namespace GreenMarket.Features.Validations.OrderItemValidation;

public sealed class UpdateOrderItemValidator : AbstractValidator<UpdateOrderItemRequest>
{
    public UpdateOrderItemValidator()
    {
        RuleFor(oi => oi.OrderItemBaseInfo.OrderId)
            .NotEmpty().WithMessage("OrderId is required.");
        
        RuleFor(oi => oi.OrderItemBaseInfo.ProductId)
            .IsInEnum().WithMessage("ProductId is required.");
        
        RuleFor(oi => oi.OrderItemBaseInfo.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
    }
}