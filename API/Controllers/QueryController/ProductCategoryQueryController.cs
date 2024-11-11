using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Queries.ProductCategoryQueries.ProductCategoryViewModels;
using GreenMarket.Filters;
using GreenMarket.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers.QueryController;

[Route("api/product-category")]
public sealed class ProductCategoryQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ProductCategoryFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetProductCategoryVm>>> response = await sender.Send(new GetProductCategoryVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get( int id)
    {
        Result<GetProductCategoryVm> response = await sender.Send(new GetProductCategoryByIdVmRequest(id));
        return response.ToActionResult();
    }
}