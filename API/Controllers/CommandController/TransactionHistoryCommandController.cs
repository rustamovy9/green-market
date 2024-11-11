using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.TransactionHistoryCommands.TransactionHistoryCommandRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers.CommandController;

[Route("api/transaction-history")]
public sealed class TransactionHistoryCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTransactionHistoryRequest transactionHistory)
    {
        BaseResult result = await sender.Send(transactionHistory);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTransactionHistoryRequest transactionHistory)
    {
        BaseResult result = await sender.Send(transactionHistory);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new DeleteTransactionHistoryRequest(id));
        return result.ToActionResult();
    }
}