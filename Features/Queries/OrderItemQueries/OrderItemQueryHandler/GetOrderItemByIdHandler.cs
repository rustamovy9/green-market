using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.OrderItemQueries.OrderItemViewModels;
using GreenMarket.Features.Queries.UserQueries.UserViewModels;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Queries.OrderItemQueries.OrderItemQueryHandler;

public class GetOrderItemByIdHandler(IUnitOfWork<OrderItem> unitOfWork) : IRequestHandler<GetOrderItemByIdVmRequest,Result<GetOrderItemVm>>
{
    public async Task<Result<GetOrderItemVm>> Handle(GetOrderItemByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<OrderItem>? repository = unitOfWork.OrderItemFindRepository;
        OrderItem? orderItem = await repository.GetByIdAsync(request.Id);
        return orderItem is null
            ? Result<GetOrderItemVm>.Failure(Error.NotFound())
            : Result<GetOrderItemVm>.Success(orderItem.ToReadInfo());
    }
}