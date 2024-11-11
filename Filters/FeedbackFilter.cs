using GreenMarket.Enums;

namespace GreenMarket.Filters;

public sealed record FeedbackFilter(Rating? MinRating,Rating? MaxRating,string? Comment) : BaseFilter;
