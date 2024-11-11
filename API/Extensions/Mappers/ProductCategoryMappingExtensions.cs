using GreenMarket.Features.BaseInfo_s;
using GreenMarket.Features.Commands.ProductCategoryCommands.ProductCategoryCommandRequest;
using GreenMarket.Features.Commands.ProductCommands.ProductCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.ProductCategoryQueries.ProductCategoryViewModels;

namespace GreenMarket.API.Extensions.Mappers;

public static class ProductCategoryMappingExtensions
{
      
    public static GetProductCategoryVm ToReadInfo(this ProductCategory productCategory)
    {
        return new()
        {
            Id = productCategory.Id,
            ProductCategoryBaseInfo = new()
            {
                Name = productCategory.Name,
                Description = productCategory.Description
            }
        };
    }
    
    
    public static ProductCategory ToProductCategory(this CreateProductCategoryRequest createInfo)
    {
        return new()
        {
            Name = createInfo.ProductCategoryBaseInfo.Name,
            Description = createInfo.ProductCategoryBaseInfo.Description
        };
    }

    public static ProductCategory ToUpdate(this ProductCategory productCategory ,UpdateProductCategoryRequest updateInfo)
    {
        productCategory.Name = updateInfo.ProductCategoryBaseInfo.Name;
        productCategory.Description = updateInfo.ProductCategoryBaseInfo.Description;
        productCategory.Version++;
        productCategory.UpdatedAt = DateTime.UtcNow;
        return productCategory;
    }

    public static ProductCategory ToDeleted(this ProductCategory productCategory)
    {
        productCategory.IsDeleted = true;
        productCategory.DeletedAt = DateTime.UtcNow;
        productCategory.UpdatedAt = DateTime.UtcNow;
        productCategory.Version++;
        return productCategory;
    }
}