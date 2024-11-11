using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Queries.FeedbackQueries.FeedbackViewModels;
using GreenMarket.Features.Queries.ProductQueries.ProductViewModels;
using GreenMarket.Filters;
using GreenMarket.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers.QueryController;


[Route("api/products")]
public sealed class ProductQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ProductFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetProductVm>>> response = await sender.Send(new GetProductVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get( int id)
    {
        Result<GetProductVm> response = await sender.Send(new GetProductByIdVmRequest(id));
        return response.ToActionResult();
    }
}