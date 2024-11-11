namespace GreenMarket.Filters;

public sealed record UserFilter(string? UserName, string? FullName, string? Address) : BaseFilter;
