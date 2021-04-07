using System;
using System.Threading.Tasks;
using SchEstimationTestingProject.Core.Banks.InfrastructureServiceInterfaces;
using SchEstimationTestingProject.Core.Common.RepositoryInterfaces;
using SchEstimationTestingProject.Core.Users.ApplicationDTOs;
using SchEstimationTestingProject.Core.Users.Entities;
using SchEstimationTestingProject.Core.Users.Exceptions;
using SchEstimationTestingProject.Core.Wallets.ApplicationDTOs;
using SchEstimationTestingProject.Core.Wallets.Entities;

namespace SchEstimationTestingProject.Core.Users.ApplicationServices
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBankServiceProvider _bankServiceProvider;

        public UserService(
            IUnitOfWork unitOfWork,
            IBankServiceProvider bankServiceProvider
        )
        {
            _unitOfWork = unitOfWork;
            _bankServiceProvider = bankServiceProvider;
        }

        public async Task<CreateNewUserResDTO> CreateNewUserAsync(CreateNewUserReqDTO data)
        {
            await _unitOfWork.BeginTransactionAsync();

            var user = await _unitOfWork.UserRepository.GetByJMBGAsync(data.UserInfo.JMBG);
            if (user != null) throw new UserAlreadyExistsException(data.UserInfo.JMBG);

            var bankService = _bankServiceProvider.Get(data.BankName);
            if (bankService == null) throw new Exception("Bank not found");

            var newPassword = "123"; //TODO: Generate new 6 digit password
            user = new User(data.UserInfo, newPassword);

            var bankStatus = await bankService.CheckStatusAsync(data.UserInfo.JMBG, data.BankAccountPIN);
            if (!bankStatus.Success)
            {
                throw new Exception(bankStatus.Message);
            }

            var wallet = new Wallet(user, data.BankName, data.BankAccountNumber, data.BankAccountPIN);

            try
            {
                await _unitOfWork.UserRepository.StoreAsync(user);
                await _unitOfWork.WalletRepository.StoreAsync(wallet);
                await _unitOfWork.CommitTransactionAsync();
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await _unitOfWork.RollbackTransactionAsync();
                await _unitOfWork.SaveChangesAsync();
                throw e;
            }

            return new CreateNewUserResDTO()
            {
                UserInfo = user.Informations,
                Password = newPassword,
                Wallet = new WalletDTO(wallet)
            };
        }

        Task ChangePasswordAsync()
        {
            throw new NotImplementedException();
        }
    }
}
