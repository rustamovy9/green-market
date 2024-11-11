using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.ProductCategoryQueries.ProductCategoryViewModels;
using GreenMarket.Features.Queries.ProductQueries.ProductViewModels;
using GreenMarket.Features.Queries.UserQueries.UserViewModels;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.Responses;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Queries.ProductCategoryQueries.ProductCategoryQueryHandler;

public sealed class GetProductCategoriesHandler(IUnitOfWork<ProductCategory> unitOfWork) : IRequestHandler<GetProductCategoryVmRequest, Result<PagedResponse<IEnumerable<GetProductCategoryVm>>>>
{

    public async Task<Result<PagedResponse<IEnumerable<GetProductCategoryVm>>>> Handle(GetProductCategoryVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<ProductCategory> repository = unitOfWork.ProductCategoryFindRepository;

        Expression<Func<ProductCategory, bool>> filterExpression = user =>
            (string.IsNullOrEmpty(request.Filter.Name) ||
             user.Name.ToLower().Contains(request.Filter.Name.ToLower())) &&
            (string.IsNullOrEmpty(request.Filter.Description) ||
             user.Description.ToLower().Contains(request.Filter.Description.ToLower()));
        
        
        IEnumerable<ProductCategory> query = (await repository
            .FindAsync(filterExpression)).ToList(); 
        
        int totalRecords =  query.Count();
        
        IEnumerable<GetProductCategoryVm> result =  query
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize)
            .Select(x => x.ToReadInfo()).ToList();
        

        PagedResponse<IEnumerable<GetProductCategoryVm>> response = PagedResponse<IEnumerable<GetProductCategoryVm>>.Create(
            request.Filter.PageNumber, 
            request.Filter.PageSize, 
            totalRecords, 
            result
        );

        return Result<PagedResponse<IEnumerable<GetProductCategoryVm>>>.Success(response);
    }
}