using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Queries.OrderQueries.OrderViewModels;
using GreenMarket.Filters;
using GreenMarket.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers.QueryController;

[Route("api/orders")]
public sealed class OrderQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] OrderFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetOrderVm>>> response = await sender.Send(new GetOrderVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get( int id)
    {
        Result<GetOrderVm> response = await sender.Send(new GetOrderByIdVmRequest(id));
        return response.ToActionResult();
    }
}