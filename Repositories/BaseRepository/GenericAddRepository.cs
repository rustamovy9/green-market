using GreenMarket.Data;
using GreenMarket.Features.Entities;

namespace GreenMarket.Repositories.BaseRepository;

public class GenericAddRepository<T>(AppCommandDbContext dbContext) : IGenericAddRepository<T> where T : BaseEntity
{
    public async Task AddAsync(T value)
    {
        await dbContext.Set<T>().AddAsync(value);
    }

    public async Task AddRangeAsync(IEnumerable<T> value)
    {
        await dbContext.Set<T>().AddRangeAsync(value);
    }
}