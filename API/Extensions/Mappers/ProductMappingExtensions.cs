using GreenMarket.Features.Commands.ProductCommands.ProductCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.ProductQueries.ProductViewModels;

namespace GreenMarket.API.Extensions.Mappers;

public static class ProductMappingExtensions
{
    
    public static GetProductVm ToReadInfo(this Product product)
    {
        return new()
        {
            Id = product.Id,
            ProductBaseInfo = new()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                FarmerId = product.FarmerId,
                CategoryId = product.CategoryId,
                HarvestDate = product.HarvestDate
            }
        };
    }
    
    
    public static Product ToProduct(this CreateProductRequest createInfo)
    {
        return new()
        {
            Name = createInfo.ProductBaseInfo.Name,
            Description = createInfo.ProductBaseInfo.Description,
            Price = createInfo.ProductBaseInfo.Price,
            Quantity = createInfo.ProductBaseInfo.Quantity,
            FarmerId = createInfo.ProductBaseInfo.FarmerId,
            CategoryId = createInfo.ProductBaseInfo.CategoryId,
            HarvestDate = createInfo.ProductBaseInfo.HarvestDate
        };
    }

    public static Product ToUpdate(this Product product ,UpdateProductRequest updateInfo)
    {
        product.Name = updateInfo.ProductBaseInfo.Name;
        product.Description = updateInfo.ProductBaseInfo.Description;
        product.Price = updateInfo.ProductBaseInfo.Price;
        product.Quantity = updateInfo.ProductBaseInfo.Quantity;
        product.FarmerId = updateInfo.ProductBaseInfo.FarmerId;
        product.CategoryId = updateInfo.ProductBaseInfo.CategoryId;
        product.Version++;
        product.UpdatedAt = DateTime.UtcNow;
        return product;
    }

    public static Product ToDeleted(this Product product)
    {
        product.IsDeleted = true;
        product.DeletedAt = DateTime.UtcNow;
        product.UpdatedAt = DateTime.UtcNow;
        product.Version++;
        return product;
    }
}