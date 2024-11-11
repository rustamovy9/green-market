using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.ProductCategoryQueries.ProductCategoryViewModels;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Queries.ProductCategoryQueries.ProductCategoryQueryHandler;

public class GetProductCategoryrByIdHandler(IUnitOfWork<ProductCategory> unitOfWork) : IRequestHandler<GetProductCategoryByIdVmRequest,Result<GetProductCategoryVm>>
{
    public async Task<Result<GetProductCategoryVm>> Handle(GetProductCategoryByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<ProductCategory>? repository = unitOfWork.ProductCategoryFindRepository;
        ProductCategory? productCategory = await repository.GetByIdAsync(request.Id);
        return productCategory is null
            ? Result<GetProductCategoryVm>.Failure(Error.NotFound())
            : Result<GetProductCategoryVm>.Success(productCategory.ToReadInfo());
    }
}