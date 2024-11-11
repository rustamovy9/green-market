using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandRequest;
using GreenMarket.Features.Commands.UserCommands.UserCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandHandler;

public class DeleteOrderItemHandler(IUnitOfWork<OrderItem> unitOfWork) : IRequestHandler<DeleteOrderItemRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteOrderItemRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<OrderItem> repository = unitOfWork.OrderItemDeleteRepository;
        IGenericFindRepository<OrderItem> findRepository = unitOfWork.OrderItemFindRepository;

        OrderItem? orderItem = await findRepository.GetByIdAsync(request.Id);
        if(orderItem is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));

        await repository.RemoveAsync(orderItem.ToDeleted());
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops! Data is not deleted🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}