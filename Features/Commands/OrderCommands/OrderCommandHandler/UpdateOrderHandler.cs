using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.OrderCommands.OrderCommandRequest;
using GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.OrderCommands.OrderCommandHandler;

public class UpdateOrderHandler(IUnitOfWork<Order> unitOfWork) : IRequestHandler<UpdateOrderRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
    {
        IGenericUpdateRepository<Order> repository = unitOfWork.OrderUpdateRepository;
        IGenericFindRepository<Order> findRepository = unitOfWork.OrderFindRepository;
        
        Order? order = await findRepository.GetByIdAsync(request.Id);
        if(order is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));;
        
        await repository.UpdateAsync(order.ToUpdate(request));
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("oops...!!! Data is not updated🤷‍♂️🤷‍♂️"))
             : BaseResult.Success();
    }
}