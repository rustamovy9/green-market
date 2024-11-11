using GreenMarket.Data;
using GreenMarket.Features.Entities;

namespace GreenMarket.Repositories.BaseRepository;

public class GenericDeleteRepository<T>(AppCommandDbContext dbContext) : IGenericDeleteRepository<T> where T : BaseEntity
{
    public async Task RemoveAsync(T value)
    {
        dbContext.Set<T>().Update(value);
    }

    public async Task RemoveRangeAsync(IEnumerable<T> value)
    {
        dbContext.Set<T>().UpdateRange(value);
    }
}