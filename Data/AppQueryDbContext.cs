using Microsoft.EntityFrameworkCore;

namespace GreenMarket.Data;

public sealed class AppQueryDbContext(DbContextOptions<BaseDbContext> options) : BaseDbContext(options);