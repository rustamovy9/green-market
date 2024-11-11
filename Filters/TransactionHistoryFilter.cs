using GreenMarket.Enums;

namespace GreenMarket.Filters;

public sealed record TransactionHistoryFilter(DateTime? StartDate,DateTime? EndDate,Status? Status) : BaseFilter;