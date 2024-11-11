using GreenMarket.API.Extensions.PatternResultExtensions;
using MediatR;

namespace GreenMarket.Features.Commands.UserCommands.UserCommandRequest;

public readonly record struct DeleteUserRequest(int Id) : IRequest<BaseResult>;