﻿using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.BaseInfo_s;
using MediatR;

namespace GreenMarket.Features.Commands.FeedbackCommands.FeedbackCommandRequest;

public readonly record struct UpdateFeedbackRequest(
    int Id,
    FeedbackBaseInfo FeedbackBaseInfo) : IRequest<BaseResult>;