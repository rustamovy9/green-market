using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.ProductCategoryCommands.ProductCategoryCommandRequest;
using GreenMarket.Features.Commands.ProductCommands.ProductCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.ProductCategoryCommands.ProductCategoryCommandHandler;

public sealed class CreateProductCategoryHandler(IUnitOfWork<ProductCategory> unitOfWork) : IRequestHandler<CreateProductCategoryRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateProductCategoryRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<ProductCategory> repository = unitOfWork.ProductCategoryAddRepository;
        IGenericFindRepository<ProductCategory> findRepository = unitOfWork.ProductCategoryFindRepository;

        bool conflict = (await findRepository.FindAsync(x =>
            x.Name.ToLower().Contains(request.ProductCategoryBaseInfo.Name.ToLower()))).Any();
        if(conflict)
            return BaseResult.Failure(Error.AlreadyExist("ooops! conflict🤷‍♂️🤷‍♂️"));
        
        await repository.AddAsync(request.ToProductCategory());
        int res = await unitOfWork.Complete();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops...!!! Data not saved🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}