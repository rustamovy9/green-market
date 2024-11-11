using System.Linq.Expressions;
using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.OrderQueries.OrderViewModels;
using GreenMarket.Features.Queries.UserQueries.UserViewModels;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.Responses;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Queries.OrderQueries.OrderQueryHandler;

public sealed class GetOrdersHandler(IUnitOfWork<User> unitOfWork) : IRequestHandler<GetOrderVmRequest, Result<PagedResponse<IEnumerable<GetOrderVm>>>>
{

    public async Task<Result<PagedResponse<IEnumerable<GetOrderVm>>>> Handle(GetOrderVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Order> repository = unitOfWork.OrderFindRepository;

        Expression<Func<Order, bool>> filterExpression = o =>
            (request.Filter.StartDate == null || o.OrderDate >= request.Filter.StartDate) &&
            (request.Filter.EndDate == null || o.OrderDate <= request.Filter.EndDate)  &&
            (request.Filter.Status == null || o.Status == request.Filter.Status);

        IEnumerable<Order> query = (await repository
            .FindAsync(filterExpression)).ToList(); 
        
        int totalRecords =  query.Count();
        
        IEnumerable<GetOrderVm> result =  query
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize)
            .Select(x => x.ToReadInfo()).ToList();
        

        PagedResponse<IEnumerable<GetOrderVm>> response = PagedResponse<IEnumerable<GetOrderVm>>.Create(
            request.Filter.PageNumber, 
            request.Filter.PageSize, 
            totalRecords, 
            result
        );

        return Result<PagedResponse<IEnumerable<GetOrderVm>>>.Success(response);
    }
}