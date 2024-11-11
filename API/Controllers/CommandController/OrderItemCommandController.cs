using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.FeedbackCommands.FeedbackCommandRequest;
using GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers.CommandController;

[Route("api/order-items")]
public sealed class OrderItemCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderItemRequest orderItem)
    {
        BaseResult result = await sender.Send(orderItem);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderItemRequest orderItem)
    {
        BaseResult result = await sender.Send(orderItem);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new DeleteOrderItemRequest(id));
        return result.ToActionResult();
    }
}