using System;
using System.Threading.Tasks;
using SchEstimationTestingProject.Core.Users.RepositoryInterfaces;
using SchEstimationTestingProject.Core.Wallets.RepositoryInterfaces;

namespace SchEstimationTestingProject.Core.Wallets.ApplicationServices
{
    public class WalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IUserRepository _userRepository;

        public WalletService(IWalletRepository walletRepository, IUserRepository userRepository)
        {
            _walletRepository = walletRepository;
            _userRepository = userRepository;
        }

        Task CreateNewWalletAsync()
        {
            throw new NotImplementedException();
        }

        Task GetWalletInfoAsync()
        {
            throw new NotImplementedException();
        }

        Task DepositAsync()
        {
            throw new NotImplementedException();
        }

        Task WithdrawAsync()
        {
            throw new NotImplementedException();
        }

        Task TransferAsync()
        {
            throw new NotImplementedException();
        }
    }
}
