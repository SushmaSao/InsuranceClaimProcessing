using Common.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Common.Persistence.Repositories
{
    public class AsyncQueryRepository<T, TContext> : IAsyncQueryRepository<T>
                                            where T : class
                                            where TContext : DbContext
    {
        protected readonly TContext _dbContext;

        public AsyncQueryRepository(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(Guid id) => await _dbContext.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await _dbContext.Set<T>().Where(predicate).AsNoTracking().ToListAsync();

    }
}
