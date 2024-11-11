using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.OrderQueries.OrderViewModels;
using GreenMarket.Features.Queries.UserQueries.UserViewModels;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Queries.OrderQueries.OrderQueryHandler;

public class GetOrderByIdHandler(IUnitOfWork<Order> unitOfWork) : IRequestHandler<GetOrderByIdVmRequest,Result<GetOrderVm>>
{
    public async Task<Result<GetOrderVm>> Handle(GetOrderByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Order>? repository = unitOfWork.OrderFindRepository;
        Order? order = await repository.GetByIdAsync(request.Id);
        return order is null
            ? Result<GetOrderVm>.Failure(Error.NotFound())
            : Result<GetOrderVm>.Success(order.ToReadInfo());
    }
}