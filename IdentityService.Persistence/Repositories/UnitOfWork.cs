using Common.Application.Contracts.Persistence;

namespace IdentityService.Persistence.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        protected readonly IdentityServiceDBContext _dbContext;

        public UnitOfWork(IdentityServiceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
