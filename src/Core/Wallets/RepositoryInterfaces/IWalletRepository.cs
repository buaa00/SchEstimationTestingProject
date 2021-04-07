using System;
using System.Threading.Tasks;
using SchEstimationTestingProject.Core.Common.RepositoryInterfaces;
using SchEstimationTestingProject.Core.Wallets.Entities;

namespace SchEstimationTestingProject.Core.Wallets.RepositoryInterfaces
{
    public interface IWalletRepository
    {
        Task StoreAsync(Wallet user);
        Task<Wallet> GetByIdAsync(string walletId);
        Task<Wallet> GetByJMBGAsync(string userJMBG);
    }
}
