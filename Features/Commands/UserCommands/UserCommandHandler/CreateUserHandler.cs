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

public sealed class CreateUserHandler(IUnitOfWork<User> unitOfWork) : IRequestHandler<CreateUserRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<User> repository = unitOfWork.UserAddRepository;
        IGenericFindRepository<User> findRepository = unitOfWork.UserFindRepository;
        
        bool conflict = (await findRepository.FindAsync(x =>
                x.UserName.ToLower().
                    Contains(request.UserBaseInfo.UserName.ToLower()) || 
                x.Email.ToLower().Contains(request.UserBaseInfo.Email.ToLower()) || 
                x.Phone.ToLower().Contains(request.UserBaseInfo.Phone))).Any();
        if(conflict)
            return BaseResult.Failure(Error.AlreadyExist("ooops! conflict🤷‍♂️🤷‍♂️"));
        

        await repository.AddAsync(request.ToUser());
        int res = await unitOfWork.Complete();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops...!!! Data not saved🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}