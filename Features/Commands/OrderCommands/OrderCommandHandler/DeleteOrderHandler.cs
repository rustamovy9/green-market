using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.OrderCommands.OrderCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.OrderCommands.OrderCommandHandler;

public class DeleteOrderHandler(IUnitOfWork<Order> unitOfWork) : IRequestHandler<DeleteOrderRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<Order> repository = unitOfWork.OrderDeleteRepository;
        IGenericFindRepository<Order> findRepository = unitOfWork.OrderFindRepository;

        Order? order = await findRepository.GetByIdAsync(request.Id);
        if(order is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));

        await repository.RemoveAsync(order.ToDeleted());
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops! Data is not deleted🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}