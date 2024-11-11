using GreenMarket.Features.Commands.FeedbackCommands.FeedbackCommandRequest;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.FeedbackQueries.FeedbackViewModels;

namespace GreenMarket.API.Extensions.Mappers;

public static class FeedbackMappingExtensions
{
    public static GetFeedbackVm ToReadInfo(this Feedback feedback)
    {
        return new()
        {
            Id = feedback.Id,
            FeedbackBaseInfo = new()
            {
                UserId = feedback.UserId,
                ProductId = feedback.ProductId,
                OrderId = feedback.OrderId,
                Comment = feedback.Comment,
                Rating = feedback.Rating,
            }
        };
    }

    public static Feedback ToFeedback(this CreateFeedbackRequest createInfo)
    {
        return new()
        {
            UserId = createInfo.FeedbackBaseInfo.UserId,
            ProductId = createInfo.FeedbackBaseInfo.ProductId,
            OrderId = createInfo.FeedbackBaseInfo.OrderId,
            Comment = createInfo.FeedbackBaseInfo.Comment,
            Rating = createInfo.FeedbackBaseInfo.Rating
        };
    }

    public static Feedback ToUpdate(this Feedback feedback ,UpdateFeedbackRequest updateInfo)
    {
        feedback.UserId = updateInfo.FeedbackBaseInfo.UserId;
        feedback.ProductId = updateInfo.FeedbackBaseInfo.ProductId;
        feedback.OrderId = updateInfo.FeedbackBaseInfo.OrderId;
        feedback.Comment = updateInfo.FeedbackBaseInfo.Comment;
        feedback.Rating = updateInfo.FeedbackBaseInfo.Rating;
        feedback.Version++;
        feedback.UpdatedAt = DateTime.UtcNow;
        return feedback;
    }

    public static Feedback ToDeleted(this Feedback feedback)
    {
        feedback.IsDeleted = true;
        feedback.DeletedAt = DateTime.UtcNow;
        feedback.UpdatedAt = DateTime.UtcNow;
        feedback.Version++;
        return feedback;
    }
}