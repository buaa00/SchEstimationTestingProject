using System;
using SchEstimationTestingProject.Core.Users.Entities;

namespace SchEstimationTestingProject.Core.Wallets.Entities
{
    public class Wallet
    {
        public string Id { get; private set; }
        public string OwnerId { get; private set; }
        public string BankName { get; private set; }
        public string BankAccountNumber { get; private set; }
        public string BankAccountPIN { get; set; }
        public decimal Balance { get; private set; }

        public Wallet(User owner, string bankName, string bankAccountNumber, string bankAccountPIN)
        {
            Id = Guid.NewGuid().ToString();
            OwnerId = owner.Id;
            BankName = bankName;
            BankAccountNumber = bankAccountNumber;
            BankAccountPIN = bankAccountPIN;
            Balance = 0;
        }

        public Wallet()
        {
            
        }
    }
}
