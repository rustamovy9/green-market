using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandRequest;
using GreenMarket.Features.Commands.ProductCommands.ProductCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.ProductCommands.ProductCommandHandler;

public class UpdateProductHandler(IUnitOfWork<Product> unitOfWork) : IRequestHandler<UpdateProductRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        IGenericUpdateRepository<Product> repository = unitOfWork.ProductUpdateRepository;
        IGenericFindRepository<Product> findRepository = unitOfWork.ProductFindRepository;
        
        Product? product = await findRepository.GetByIdAsync(request.Id);
        if(product is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));;
        
        await repository.UpdateAsync(product.ToUpdate(request));
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("oops...!!! Data is not updated🤷‍♂️🤷‍♂️"))
             : BaseResult.Success();
    }
}