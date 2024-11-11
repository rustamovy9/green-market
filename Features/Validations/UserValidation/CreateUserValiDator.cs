using FluentValidation;
using GreenMarket.Features.Commands.UserCommands.UserCommandRequest;

namespace GreenMarket.Features.Validations.UserValidation;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.UserBaseInfo.FullName)
            .NotEmpty().WithMessage("FullName is required.")
            .Length(4, 30).WithMessage("FullName must be between 4 and 30 characters.");
        
        RuleFor(user => user.UserBaseInfo.UserName)
            .NotEmpty().WithMessage("Username is required.")
            .Length(4, 30).WithMessage("Username must be between 4 and 30 characters.");

        RuleFor(user => user.UserBaseInfo.Email)
            .NotEmpty().WithMessage("Email address is required.")
            .EmailAddress().WithMessage("Invalid email address format.")
            .Length(4, 50).WithMessage("Email address must be between 4 and 50 characters.");

         RuleFor(user => user.UserBaseInfo.Phone)
            .NotEmpty().WithMessage("Phone  is required.")
            .Length(13).WithMessage("Phone  must be exactly 13 characters.");
        
        RuleFor(user => user.UserBaseInfo.Address)
            .NotEmpty().WithMessage("Address is required.")
            .Length(4, 50).WithMessage("Address must be between 4 and 50 characters.");
        
        RuleFor(user => user.UserBaseInfo.Role)
            .IsInEnum().WithMessage("Role must be either Businessman or Farmer.");
        
    }
}