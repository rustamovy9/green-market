using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.FeedbackCommands.FeedbackCommandHandler;
using GreenMarket.Features.Commands.FeedbackCommands.FeedbackCommandRequest;
using GreenMarket.Features.Commands.TransactionHistoryCommands.TransactionHistoryCommandRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers.CommandController;

[Route("api/feedback")]
public sealed class FeedbackCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFeedbackRequest feedback)
    {
        BaseResult result = await sender.Send(feedback);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFeedbackRequest feedbackRequest)
    {
        BaseResult result = await sender.Send(feedbackRequest);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new DeleteFeedbackRequest(id));
        return result.ToActionResult();
    }
}