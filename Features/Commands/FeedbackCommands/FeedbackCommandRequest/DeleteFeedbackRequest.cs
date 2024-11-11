using GreenMarket.API.Extensions.PatternResultExtensions;
using MediatR;

namespace GreenMarket.Features.Commands.FeedbackCommands.FeedbackCommandRequest;

public readonly record struct DeleteFeedbackRequest(int Id) : IRequest<BaseResult>;