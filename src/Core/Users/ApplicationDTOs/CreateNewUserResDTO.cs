using System;
using SchEstimationTestingProject.Core.Users.ValueObjects;
using SchEstimationTestingProject.Core.Wallets.ApplicationDTOs;

namespace SchEstimationTestingProject.Core.Users.ApplicationDTOs
{
    public class CreateNewUserResDTO
    {
        public WalletDTO Wallet { get; set; }
        public UserInfo UserInfo { get; set; }
        public string Password { get; set; }
    }
}
