﻿using FluentValidation;
using GreenMarket.Features.Commands.FeedbackCommands.FeedbackCommandRequest;

namespace GreenMarket.Features.Validations.FeedbackValidation;

public sealed class CreateFeedbackValidator : AbstractValidator<CreateFeedbackRequest>
{
    public CreateFeedbackValidator()
    {
        RuleFor(f => f.FeedbackBaseInfo.UserId)
           .NotEmpty().WithMessage("UserId is required.");
        
        RuleFor(f => f.FeedbackBaseInfo.Rating)
           .IsInEnum().WithMessage("Rating is enum.");
    }
}