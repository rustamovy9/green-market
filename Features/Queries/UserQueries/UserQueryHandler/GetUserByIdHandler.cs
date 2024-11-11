using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.UserQueries.UserViewModels;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Queries.UserQueries.UserQueryHandler;

public class GetUserByIdHandler(IUnitOfWork<User> unitOfWork) : IRequestHandler<GetUserByIdVmRequest,Result<GetUserVm>>
{
    public async Task<Result<GetUserVm>> Handle(GetUserByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<User>? repository = unitOfWork.UserFindRepository;
        User? user = await repository.GetByIdAsync(request.Id);
        return user is null
            ? Result<GetUserVm>.Failure(Error.NotFound())
            : Result<GetUserVm>.Success(user.ToReadInfo());
    }
}