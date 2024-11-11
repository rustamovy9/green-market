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

public class UpdateUserHandler(IUnitOfWork<User> unitOfWork) : IRequestHandler<UpdateUserRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        IGenericUpdateRepository<User> repository = unitOfWork.UserUpdateRepository;
        IGenericFindRepository<User> findRepository = unitOfWork.UserFindRepository;
        
        User? user = await findRepository.GetByIdAsync(request.Id);
        if(user is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));;
        
        
        bool conflict = (await findRepository.FindAsync(x =>
            x.UserName.ToLower().
                Contains(request.UserBaseInfo.UserName.ToLower()) || 
            x.Email.ToLower().Contains(request.UserBaseInfo.Email.ToLower()) || 
            x.Phone.ToLower().Contains(request.UserBaseInfo.Phone))).Any();
        if(conflict)
            return BaseResult.Failure(Error.AlreadyExist("ooops! conflict🤷‍♂️🤷‍♂️"));

        
        await repository.UpdateAsync(user.ToUpdate(request));
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("oops...!!! Data is not updated🤷‍♂️🤷‍♂️"))
             : BaseResult.Success();
    }
}