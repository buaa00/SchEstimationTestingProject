using SchEstimationTestingProject.Core.Users.ValueObjects;

namespace SchEstimationTestingProject.Core.Users.ApplicationDTOs
{
    public class CreateNewUserReqDTO
    {
        public UserInfo UserInfo { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountPIN { get; set; }
    }
}