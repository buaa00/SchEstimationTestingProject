using System;
using System.Threading.Tasks;

namespace SchEstimationTestingProject.Core.Banks.InfrastructureServiceInterfaces
{
    public interface IBankProviderService
    {
        Task CheckStatusAsync(string jmbg, string pin);
        Task DepositAsync(string jmbg, string pin, decimal amount);
        Task WithdrawAsync(string jmbg, string pin, decimal amount);
    }
}
