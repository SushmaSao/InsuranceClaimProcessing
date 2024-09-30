namespace Common.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
