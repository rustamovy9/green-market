using Microsoft.EntityFrameworkCore;

namespace GreenMarket.Data;

public sealed class AppCommandDbContext(DbContextOptions<BaseDbContext> options) : BaseDbContext(options);