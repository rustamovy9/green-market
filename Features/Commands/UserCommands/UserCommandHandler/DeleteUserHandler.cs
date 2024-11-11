using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Data;
using GreenMarket.Features.Commands.UserCommands.UserCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GreenMarket.Features.Commands.UserCommands.UserCommandHandler;

public class DeleteUserHandler(IUnitOfWork<User> unitOfWork) : IRequestHandler<DeleteUserRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<User> repository = unitOfWork.UserDeleteRepository;
        IGenericFindRepository<User> findRepository = unitOfWork.UserFindRepository;

        User? user = await findRepository.GetByIdAsync(request.Id);
        if(user is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));

        await repository.RemoveAsync(user.ToDeleted());
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops! Data is not deleted🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}