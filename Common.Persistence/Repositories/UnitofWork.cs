using Common.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Common.Persistence.Repositories
{
    public sealed class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        protected readonly TContext _dbContext;

        public UnitOfWork(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
