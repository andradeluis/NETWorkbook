using EFRepositoryUoW.Core.IRepositories;

namespace EFRepositoryUoW.Core.Configuration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CompleteAsync();
    }
}
