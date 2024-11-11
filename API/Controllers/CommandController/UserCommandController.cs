using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Controllers;
using GreenMarket.Features.Commands.UserCommands.UserCommandRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers.CommandController;

[Route("api/users")]
public sealed class UserCommandController(ISender sender) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest user)
    {
        BaseResult result = await sender.Send(user);
        return result.ToActionResult();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserRequest user)
    {
        BaseResult result = await sender.Send(user);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        BaseResult result = await sender.Send(new DeleteUserRequest(id));
        return result.ToActionResult();
    }
}