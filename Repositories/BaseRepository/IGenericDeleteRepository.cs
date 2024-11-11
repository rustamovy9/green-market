using GreenMarket.Features.Entities;

namespace GreenMarket.Repositories.BaseRepository;

public interface IGenericDeleteRepository<T> where T : BaseEntity
{
    Task RemoveAsync(T value);
    Task RemoveRangeAsync(IEnumerable<T> value);
}