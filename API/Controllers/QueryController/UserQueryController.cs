using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Controllers;
using GreenMarket.Features.Queries.UserQueries.UserViewModels;
using GreenMarket.Filters;
using GreenMarket.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers.QueryController;

[Route("api/users")]
public sealed class UserQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] UserFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetUserVm>>> response = await sender.Send(new GetUserVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get( int id)
    {
        Result<GetUserVm> response = await sender.Send(new GetUserByIdVmRequest(id));
        return response.ToActionResult();
    }
}