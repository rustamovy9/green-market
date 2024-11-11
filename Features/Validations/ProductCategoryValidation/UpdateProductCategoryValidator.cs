using FluentValidation;
using GreenMarket.Features.Commands.ProductCategoryCommands.ProductCategoryCommandRequest;

namespace GreenMarket.Features.Validations.ProductCategoryValidation;

public sealed class UpdateProductCategoryValidator : AbstractValidator<UpdateProductCategoryRequest>
{
    public UpdateProductCategoryValidator()
    {
        RuleFor(pc => pc.ProductCategoryBaseInfo.Name)
            .NotEmpty().WithMessage("FullName is required.")
            .Length(4, 30).WithMessage("FullName must be between 4 and 30 characters.");
        
        RuleFor(pc => pc.ProductCategoryBaseInfo.Description)
            .NotEmpty().WithMessage("Username is required.")
            .Length(4, 30).WithMessage("Username must be between 4 and 30 characters.");
    }
}