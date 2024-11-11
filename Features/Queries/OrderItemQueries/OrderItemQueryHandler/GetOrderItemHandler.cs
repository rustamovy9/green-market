using System.Linq.Expressions;
using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.OrderItemQueries.OrderItemViewModels;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.Responses;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Queries.OrderItemQueries.OrderItemQueryHandler;

public sealed class GetOrderItemHandler(IUnitOfWork<OrderItem> unitOfWork) : IRequestHandler<GetOrderItemVmRequest, Result<PagedResponse<IEnumerable<GetOrderItemVm>>>>
{

    public async Task<Result<PagedResponse<IEnumerable<GetOrderItemVm>>>> Handle(GetOrderItemVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<OrderItem> repository = unitOfWork.OrderItemFindRepository;

        Expression<Func<OrderItem, bool>> filterExpression = oi =>
            (request.Filter.MinQuantity == null || oi.Quantity >= request.Filter.MinQuantity) &&
            (request.Filter.MaxQuantity == null || oi.Quantity <= request.Filter.MaxQuantity) &&
            (request.Filter.MinTotalPrice == null || oi.TotalPrice >= request.Filter.MinTotalPrice) &&
            (request.Filter.MaxTotalPrice == null || oi.TotalPrice <= request.Filter.MaxTotalPrice);

        IEnumerable<OrderItem> query = (await repository
            .FindAsync(filterExpression)).ToList(); 
        
        int totalRecords =  query.Count();
        
        IEnumerable<GetOrderItemVm> result =  query
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize)
            .Select(x => x.ToReadInfo()).ToList();
        

        PagedResponse<IEnumerable<GetOrderItemVm>> response = PagedResponse<IEnumerable<GetOrderItemVm>>.Create(
            request.Filter.PageNumber, 
            request.Filter.PageSize, 
            totalRecords, 
            result
        );

        return Result<PagedResponse<IEnumerable<GetOrderItemVm>>>.Success(response);
    }
}
