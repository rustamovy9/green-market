using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.ProductQueries.ProductViewModels;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Queries.ProductQueries.ProductQueryHandler;

public class GetProductByIdHandler(IUnitOfWork<Product> unitOfWork) : IRequestHandler<GetProductByIdVmRequest,Result<GetProductVm>>
{
    public async Task<Result<GetProductVm>> Handle(GetProductByIdVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Product>? repository = unitOfWork.ProductFindRepository;
        Product? product = await repository.GetByIdAsync(request.Id);
        return product is null
            ? Result<GetProductVm>.Failure(Error.NotFound())
            : Result<GetProductVm>.Success(product.ToReadInfo());
    }
}