using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.OrderCommands.OrderCommandRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers.CommandController;

[Route("api/orders")]
public sealed class OrderCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest order)
    {
        BaseResult result = await sender.Send(order);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderRequest order)
    {
        BaseResult result = await sender.Send(order);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new DeleteOrderRequest(id));
        return result.ToActionResult();
    }
}