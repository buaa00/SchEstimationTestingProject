using System;
using System.Threading.Tasks;
using SchEstimationTestingProject.Core.Wallets.Entities;

namespace SchEstimationTestingProject.Core.Wallets.RepositoryInterfaces
{
    public interface IWalletRepository
    {
        Task SaveAsync(Wallet user);
        Task<Wallet> GetByIdAsync(string walletId);
        Task<Wallet> GetByJMBGAsync(string userJMBG);
    }
}
