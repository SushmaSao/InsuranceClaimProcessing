using System.Linq.Expressions;

namespace Common.Application.Contracts.Persistence
{
    public interface IAsyncQueryRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
