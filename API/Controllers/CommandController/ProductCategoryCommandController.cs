using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.FeedbackCommands.FeedbackCommandRequest;
using GreenMarket.Features.Commands.ProductCategoryCommands.ProductCategoryCommandRequest;
using GreenMarket.Features.Commands.ProductCommands.ProductCommandRequest;
using GreenMarket.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers.CommandController;

[Route("api/product-category")]
public sealed class ProductCategoryCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCategoryRequest productCategory)
    {
        BaseResult result = await sender.Send(productCategory);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductCategoryRequest productCategory)
    {
        BaseResult result = await sender.Send(productCategory);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new DeleteProductCategoryRequest(id));
        return result.ToActionResult();
    }
}