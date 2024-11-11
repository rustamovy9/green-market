using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.ProductCategoryCommands.ProductCategoryCommandRequest;
using GreenMarket.Features.Commands.ProductCommands.ProductCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.ProductCategoryCommands.ProductCategoryCommandHandler;

public class UpdateProductCategoryHandler(IUnitOfWork<Product> unitOfWork) : IRequestHandler<UpdateProductCategoryRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateProductCategoryRequest request, CancellationToken cancellationToken)
    {
        IGenericUpdateRepository<ProductCategory> repository = unitOfWork.ProductCategoryUpdateRepository;
        IGenericFindRepository<ProductCategory> findRepository = unitOfWork.ProductCategoryFindRepository;
        
        bool conflict = (await findRepository.FindAsync(x =>
            x.Name.ToLower().Contains(request.ProductCategoryBaseInfo.Name.ToLower()))).Any();
        if(conflict)
            return BaseResult.Failure(Error.AlreadyExist("ooops! conflict🤷‍♂️🤷‍♂️"));
        
        ProductCategory? productCategory = await findRepository.GetByIdAsync(request.Id);
        if(productCategory is null)
            return BaseResult.Failure(Error.NotFound("ooops! Data not found🤷‍♂️🤷‍♂️"));;
        
        await repository.UpdateAsync(productCategory.ToUpdate(request));
        int res = await unitOfWork.Complete();
        
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("oops...!!! Data is not updated🤷‍♂️🤷‍♂️"))
             : BaseResult.Success();
    }
}