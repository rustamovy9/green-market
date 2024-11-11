using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Queries.FeedbackQueries.FeedbackViewModels;
using GreenMarket.Features.Queries.UserQueries.UserViewModels;
using GreenMarket.Filters;
using GreenMarket.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers.QueryController;

[Route("api/feedback")]
public sealed class FeedbackQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] FeedbackFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetFeedbackVm>>> response = await sender.Send(new GetFeedbackVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get( int id)
    {
        Result<GetFeedbackVm> response = await sender.Send(new GetFeedbackByIdVmRequest(id));
        return response.ToActionResult();
    }
}