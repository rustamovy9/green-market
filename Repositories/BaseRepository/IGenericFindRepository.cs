using System.Linq.Expressions;
using GreenMarket.Features.Entities;

namespace GreenMarket.Repositories.BaseRepository;

public interface IGenericFindRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
}