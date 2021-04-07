using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SchEstimationTestingProject.Core.Banks.InfrastructureServiceInterfaces;

namespace SchEstimationTestingProject.Infrastructure.Banks.InfrastructureServices
{
    public class BankServiceProvider : IBankServiceProvider
    {
        public Dictionary<string, IBankService> ServiceProvider { get; set; }

        public BankServiceProvider()
        {
            ServiceProvider = new Dictionary<string, IBankService>();
        }

        public void Add(string bankName, IBankService bankProviderService)
        {
            ServiceProvider[bankName] = bankProviderService;
        }

        public IBankService Get(string bankName)
        {
            return ServiceProvider.GetValueOrDefault(bankName);
        }
    }
}
