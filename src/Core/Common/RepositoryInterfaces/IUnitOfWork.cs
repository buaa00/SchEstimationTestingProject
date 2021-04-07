using System;
using System.Threading.Tasks;
using SchEstimationTestingProject.Core.Users.RepositoryInterfaces;
using SchEstimationTestingProject.Core.Wallets.RepositoryInterfaces;

namespace SchEstimationTestingProject.Core.Common.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task SaveChangesAsync();
        IUserRepository UserRepository { get; }
        IWalletRepository WalletRepository { get; }
    }
}
