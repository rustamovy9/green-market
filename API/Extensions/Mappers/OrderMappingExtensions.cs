using GreenMarket.Enums;
using GreenMarket.Features.Commands.OrderCommands.OrderCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.OrderQueries.OrderViewModels;

namespace GreenMarket.API.Extensions.Mappers;

public static class OrderMappingExtensions
{
    public static GetOrderVm ToReadInfo(this Order order)
    {
        return new()
        {
            Id = order.Id,
            OrderBaseInfo = new()
            {
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                Status = Status.Completed,
                TotalAmount = order.TotalAmount
            }
        };
    }

    public static Order ToOrder(this CreateOrderRequest createInfo)
    {
        return new()
        {
            UserId = createInfo.OrderBaseInfo.UserId,
            Status = Status.Pending,
            OrderDate = createInfo.OrderBaseInfo.OrderDate,
            TotalAmount = createInfo.OrderBaseInfo.TotalAmount
        };
    }

    public static Order ToUpdate(this Order order ,UpdateOrderRequest updateInfo)
    {
        order.UserId = updateInfo.OrderBaseInfo.UserId;
        order.OrderDate = updateInfo.OrderBaseInfo.OrderDate;
        order.TotalAmount = updateInfo.OrderBaseInfo.TotalAmount;
        order.Status = Status.Processing;
        order.Version++;
        order.UpdatedAt = DateTime.UtcNow;
        return order;
    }

    public static Order ToDeleted(this Order order)
    {
        order.Status = Status.Cancelled;
        order.IsDeleted = true;
        order.DeletedAt = DateTime.UtcNow;
        order.UpdatedAt = DateTime.UtcNow;
        order.Version++;
        return order;
    }
}