using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandRequest;
using GreenMarket.Features.Commands.UserCommands.UserCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandHandler;

public sealed class CreateOrderItemHandler(IUnitOfWork<OrderItem> unitOfWork) : IRequestHandler<CreateOrderItemRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateOrderItemRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<OrderItem> repository = unitOfWork.OrderItemAddRepository;
        
        await repository.AddAsync(request.ToOrderItem());
        int res = await unitOfWork.Complete();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops...!!! Data not saved🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}