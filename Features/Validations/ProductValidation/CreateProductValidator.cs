using FluentValidation;
using GreenMarket.Features.Commands.ProductCommands.ProductCommandRequest;

namespace GreenMarket.Features.Validations.ProductValidation;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(user => user.ProductBaseInfo.Name)
            .NotEmpty().WithMessage("FullName is required.")
            .Length(4, 30).WithMessage("FullName must be between 4 and 30 characters.");
        
        RuleFor(user => user.ProductBaseInfo.Description)
            .NotEmpty().WithMessage("Username is required.")
            .Length(4, 30).WithMessage("Username must be between 4 and 30 characters.");
    }
}