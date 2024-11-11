using System.Linq.Expressions;
using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.UserQueries.UserViewModels;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.Responses;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Queries.UserQueries.UserQueryHandler;

public sealed class GetUsersHandler(IUnitOfWork<User> unitOfWork) : IRequestHandler<GetUserVmRequest, Result<PagedResponse<IEnumerable<GetUserVm>>>>
{

    public async Task<Result<PagedResponse<IEnumerable<GetUserVm>>>> Handle(GetUserVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<User> repository = unitOfWork.UserFindRepository;

        Expression<Func<User, bool>> filterExpression = user =>
            (string.IsNullOrEmpty(request.Filter.UserName) || user.UserName.ToLower().Contains(request.Filter.UserName.ToLower())) &&
            (string.IsNullOrEmpty(request.Filter.FullName) || user.FullName.ToLower().Contains(request.Filter.FullName.ToLower())) &&
            (string.IsNullOrEmpty(request.Filter.Address) || user.Address.ToLower().Contains(request.Filter.Address.ToLower()));

        IEnumerable<User> query = (await repository
            .FindAsync(filterExpression)).ToList(); 
        
        int totalRecords =  query.Count();
        
        IEnumerable<GetUserVm> result =  query
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize)
            .Select(x => x.ToReadInfo()).ToList();
        

        PagedResponse<IEnumerable<GetUserVm>> response = PagedResponse<IEnumerable<GetUserVm>>.Create(
            request.Filter.PageNumber, 
            request.Filter.PageSize, 
            totalRecords, 
            result
        );

        return Result<PagedResponse<IEnumerable<GetUserVm>>>.Success(response);
    }
}
