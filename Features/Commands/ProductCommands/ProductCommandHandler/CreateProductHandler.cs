using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Features.Commands.ProductCommands.ProductCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.UOW;
using MediatR;

namespace GreenMarket.Features.Commands.ProductCommands.ProductCommandHandler;

public sealed class CreateProductHandler(IUnitOfWork<Product> unitOfWork) : IRequestHandler<CreateProductRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        IGenericAddRepository<Product> repository = unitOfWork.ProductAddRepository;
        
        await repository.AddAsync(request.ToProduct());
        int res = await unitOfWork.Complete();

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("ooops...!!! Data not saved🤷‍♂️🤷‍♂️"))
            : BaseResult.Success();
    }
}