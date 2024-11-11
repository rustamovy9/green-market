// using System.Linq.Expressions;
// using Microsoft.EntityFrameworkCore;
// using UnitOfWork.DataAccess;
// using UnitOfWork.Entities;
//
// namespace UnitOfWork.Repositories.BaseRepository;
//
// public class GenericRepository<T>(DataContext dbContext):IGenericRepository<T> where T : BaseEntity
// {
//     public async Task<int> AddAsync(T value)
//     {
//         await dbContext.Set<T>().AddAsync(value);
//         return await dbContext.SaveChangesAsync();
//     }
//
//     public async Task<int> AddRangeAsync(IEnumerable<T> value)
//     {
//         await dbContext.Set<T>().AddRangeAsync(value);
//         return await dbContext.SaveChangesAsync();
//     }
//     public async Task<T?> GetByIdAsync(int id)
//     {
//         return await dbContext.Set<T>().Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
//     }
//
//     public async Task<IEnumerable<T>> GetAllAsync()
//     {
//         return await dbContext.Set<T>().Where(x => !x.IsDeleted).ToListAsync();
//     }
//
//     public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
//     {
//         return await dbContext.Set<T>().Where(x => !x.IsDeleted).Where(expression).ToListAsync();
//     }
//     public async Task<int> RemoveAsync(T value)
//     {
//         dbContext.Set<T>().Remove(value);
//         return await dbContext.SaveChangesAsync();
//     }
//
//     public async Task<int> RemoveRangeAsync(IEnumerable<T> value)
//     {
//         dbContext.Set<T>().RemoveRange(value);
//         return await dbContext.SaveChangesAsync();
//     }
//     public async Task<int> UpdateAsync(T value)
//     {
//         dbContext.Set<T>().Update(value);
//         return await dbContext.SaveChangesAsync();
//     }
//
//     public async Task<int> UpdateRangeAsync(IEnumerable<T> value)
//     {
//         dbContext.Set<T>().UpdateRange(value);
//         return await dbContext.SaveChangesAsync();
//     }
// }