namespace GreenMarket.Filters;

public record OrderItemFilter(int? MinQuantity,int? MaxQuantity,decimal? MinTotalPrice,decimal? MaxTotalPrice) : BaseFilter;