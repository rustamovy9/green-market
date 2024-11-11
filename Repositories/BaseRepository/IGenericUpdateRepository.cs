using GreenMarket.Features.Entities;

namespace GreenMarket.Repositories.BaseRepository;

public interface IGenericUpdateRepository<T> where T : BaseEntity
{
    Task UpdateAsync(T value);
    Task UpdateRangeAsync(IEnumerable<T> value);
}