using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.ProductCategoryCommands.ProductCategoryCommandRequest;
using GreenMarket.Features.Commands.ProductCommands.ProductCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.ProductCategoryCommands.ProductCategoryCommandHandler;

public class DeleteProductCategoryHandler(IUnitOfWork<ProductCategory> unitOfWork) : IRequestHandler<DeleteProductCategoryRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteProductCategoryRequest request, CancellationToken cancellationToken)
    {
        IGenericDeleteRepository<ProductCategory> repository = unitOfWork.ProductCategoryDeleteRepository;
        IGenericFindRepository<ProductCategory> findRepository = unitOfWork.ProductCategoryFindRepository;

        ProductCategory? productCategory = await findRepository.GetByIdAsync(request.Id);
        if(productCategory is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));

        await repository.RemoveAsync(productCategory.ToDeleted());
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops! Data is not deleted🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}