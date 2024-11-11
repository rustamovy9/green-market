using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Queries.TransactionHistoryQueries.TransactionHistoryViewModels;
using GreenMarket.Features.Queries.UserQueries.UserViewModels;
using GreenMarket.Filters;
using GreenMarket.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers.QueryController;

[Route("api/transaction-history")]
public sealed class TransactionHistoryQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] TransactionHistoryFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetTransactionHistoryVm>>> response = await sender.Send(new GetTransactionHistoryVmRequest(filter));
        return response.ToActionResult();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get( int id)
    {
        Result<GetTransactionHistoryVm> response = await sender.Send(new GetTransactionHistoryByIdVmRequest(id));
        return response.ToActionResult();
    }
}