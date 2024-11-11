using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.OrderCommands.OrderCommandRequest;
using GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.OrderCommands.OrderCommandHandler;

public sealed class CreateOrderHandler(IUnitOfWork<Order> unitOfWork) : IRequestHandler<CreateOrderRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<Order> repository = unitOfWork.OrderAddRepository;
        
        await repository.AddAsync(request.ToOrder());
        int res = await unitOfWork.Complete();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops...!!! Data not saved🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}