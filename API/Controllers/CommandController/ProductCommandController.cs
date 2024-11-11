using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.ProductCommands.ProductCommandRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace GreenMarket.API.Controllers.CommandController;


[Route("api/products")]
public sealed class ProductCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest product)
    {
        BaseResult result = await sender.Send(product);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductRequest product)
    {
        BaseResult result = await sender.Send(product);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new DeleteProductRequest(id));
        return result.ToActionResult();
    }
}