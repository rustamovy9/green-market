using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Queries.OrderItemQueries.OrderItemViewModels;
using GreenMarket.Filters;
using GreenMarket.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers.QueryController;

[Route("api/order-items")]
public sealed class OrderItemQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] OrderItemFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetOrderItemVm>>> response = await sender.Send(new GetOrderItemVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get( int id)
    {
        Result<GetOrderItemVm> response = await sender.Send(new GetOrderItemByIdVmRequest(id));
        return response.ToActionResult();
    }
}