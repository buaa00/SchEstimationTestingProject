using SchEstimationTestingProject.Core.Wallets.Entities;

namespace SchEstimationTestingProject.Core.Wallets.ApplicationDTOs
{
    public class WalletDTO
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public decimal Balance { get; set; }

        public WalletDTO()
        {
            
        }

        public WalletDTO(Wallet wallet)
        {
            Id = wallet.Id;
            OwnerId = wallet.OwnerId;
            BankName = wallet.BankName;
            BankAccountNumber = wallet.BankAccountNumber;
            Balance = wallet.Balance;
        }
    }
}
