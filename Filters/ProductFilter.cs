namespace GreenMarket.Filters;

public record ProductFilter(string? Name,string? Description,decimal? MinPrice,decimal? MaxPrice,DateTime? StartDate,DateTime? EndDate) : BaseFilter;