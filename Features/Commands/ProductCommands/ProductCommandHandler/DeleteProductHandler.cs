using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandRequest;
using GreenMarket.Features.Commands.ProductCommands.ProductCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.ProductCommands.ProductCommandHandler;

public class DeleteProductHandler(IUnitOfWork<Product> unitOfWork) : IRequestHandler<DeleteProductRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<Product> repository = unitOfWork.ProductDeleteRepository;
        IGenericFindRepository<Product> findRepository = unitOfWork.ProductFindRepository;

        Product? product = await findRepository.GetByIdAsync(request.Id);
        if(product is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));

        await repository.RemoveAsync(product.ToDeleted());
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops! Data is not deleted🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}