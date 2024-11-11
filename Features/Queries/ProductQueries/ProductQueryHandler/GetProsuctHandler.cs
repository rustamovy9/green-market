using System.Linq.Expressions;
using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.ProductQueries.ProductViewModels;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.Responses;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Queries.ProductQueries.ProductQueryHandler;

public sealed class GetProsuctHandler(IUnitOfWork<Product> unitOfWork) : IRequestHandler<GetProductVmRequest, Result<PagedResponse<IEnumerable<GetProductVm>>>>
{

    public async Task<Result<PagedResponse<IEnumerable<GetProductVm>>>> Handle(GetProductVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Product> repository = unitOfWork.ProductFindRepository;

        Expression<Func<Product, bool>> filterExpression = p =>
            (string.IsNullOrEmpty(request.Filter.Name) || p.Name.ToLower().Contains(request.Filter.Name.ToLower())) &&
            (string.IsNullOrEmpty(request.Filter.Description) ||
             p.Description.ToLower().Contains(request.Filter.Description.ToLower())) &&
            (request.Filter.MinPrice == null || p.Price >= request.Filter.MinPrice) &&
            (request.Filter.MaxPrice == null || p.Price <= request.Filter.MaxPrice) &&
            (request.Filter.StartDate == null || p.HarvestDate >= request.Filter.StartDate) &&
            (request.Filter.EndDate == null || p.HarvestDate <= request.Filter.EndDate);

        IEnumerable<Product> query = (await repository
            .FindAsync(filterExpression)).ToList(); 
        
        int totalRecords =  query.Count();
        
        IEnumerable<GetProductVm> result =  query
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize)
            .Select(x => x.ToReadInfo()).ToList();
        

        PagedResponse<IEnumerable<GetProductVm>> response = PagedResponse<IEnumerable<GetProductVm>>.Create(
            request.Filter.PageNumber, 
            request.Filter.PageSize, 
            totalRecords, 
            result
        );

        return Result<PagedResponse<IEnumerable<GetProductVm>>>.Success(response);
    }
}