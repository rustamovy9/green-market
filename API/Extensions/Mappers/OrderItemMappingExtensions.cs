using GreenMarket.Enums;
using GreenMarket.Features.Commands.OrderItemCommands.OrderItemCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.OrderItemQueries.OrderItemViewModels;

namespace GreenMarket.API.Extensions.Mappers;

public static class OrderItemMappingExtensions
{
    public static GetOrderItemVm ToReadInfo(this OrderItem orderItem)
    {
        return new()
        {
            Id = orderItem.Id,
            TotalPrice = orderItem.TotalPrice,
            OrderItemBaseInfo = new()
            {
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
            }
        };
    }

    public static OrderItem ToOrderItem(this CreateOrderItemRequest createInfo)
    {
        return new()
        {
            OrderId = createInfo.OrderItemBaseInfo.OrderId,
            ProductId = createInfo.OrderItemBaseInfo.ProductId,
            Quantity = createInfo.OrderItemBaseInfo.Quantity,
        };
    }

    public static OrderItem ToUpdate(this OrderItem orderItem ,UpdateOrderItemRequest updateInfo)
    {
        orderItem.ProductId = updateInfo.OrderItemBaseInfo.ProductId;
        orderItem.OrderId = updateInfo.OrderItemBaseInfo.OrderId;
        orderItem.Quantity = updateInfo.OrderItemBaseInfo.Quantity;
        orderItem.Version++;
        orderItem.UpdatedAt = DateTime.UtcNow;
        return orderItem;
    }

    public static OrderItem ToDeleted(this OrderItem orderItem)
    {
        orderItem.IsDeleted = true;
        orderItem.DeletedAt = DateTime.UtcNow;
        orderItem.UpdatedAt = DateTime.UtcNow;
        orderItem.Version++;
        return orderItem;
    }
}