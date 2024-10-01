using Common.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Common.Persistence.Repositories
{
    public class AsyncRepository<T, TContext> : IAsyncRepository<T>
                                            where T : class
                                            where TContext : DbContext
    {
        protected readonly TContext _dbContext;

        public AsyncRepository(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return Task.CompletedTask;
        }

        public async Task<T> GetByIdAsync(Guid id) => await _dbContext.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();


        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await _dbContext.Set<T>().Where(predicate).AsNoTracking().ToListAsync();


        public async Task AddAsync(T entity) => await _dbContext.Set<T>().AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<T> entities) => await _dbContext.Set<T>().AddRangeAsync(entities);

        public Task RemoveAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            return Task.CompletedTask;
        }
    }
}
