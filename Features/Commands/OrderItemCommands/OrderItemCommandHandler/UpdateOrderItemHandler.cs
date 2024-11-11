using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandRequest;
using GreenMarket.Features.Commands.UserCommands.UserCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandHandler;

public class UpdateOrderItemHandler(IUnitOfWork<OrderItem> unitOfWork) : IRequestHandler<UpdateOrderItemRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateOrderItemRequest request, CancellationToken cancellationToken)
    {
        IGenericUpdateRepository<OrderItem> repository = unitOfWork.OrderItemUpdateRepository;
        IGenericFindRepository<OrderItem> findRepository = unitOfWork.OrderItemFindRepository;
        
        OrderItem? orderItem = await findRepository.GetByIdAsync(request.Id);
        if(orderItem is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));;
        
        await repository.UpdateAsync(orderItem.ToUpdate(request));
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("oops...!!! Data is not updated🤷‍♂️🤷‍♂️"))
             : BaseResult.Success();
    }
}