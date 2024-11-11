using System.Runtime.InteropServices.JavaScript;
using GreenMarket.Enums;

namespace GreenMarket.Filters;

public record OrderFilter(DateTime? StartDate,DateTime? EndDate,Status? Status) : BaseFilter;