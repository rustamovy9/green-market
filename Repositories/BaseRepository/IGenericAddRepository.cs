using GreenMarket.Features.Entities;

namespace GreenMarket.Repositories.BaseRepository;

public interface IGenericAddRepository<T> where T : BaseEntity
{
    Task AddAsync(T value);
    Task AddRangeAsync(IEnumerable<T> value);
}