using GreenMarket.Data;
using GreenMarket.Features.Entities;

namespace GreenMarket.Repositories.BaseRepository;

public class GenericUpdateRepository<T>(AppCommandDbContext dbContext) : IGenericUpdateRepository<T> where T : BaseEntity
{
    public async Task UpdateAsync(T value)
    {
        dbContext.Set<T>().Update(value);
    }

    public async Task UpdateRangeAsync(IEnumerable<T> value)
    {
        dbContext.Set<T>().UpdateRange(value);
    }
}