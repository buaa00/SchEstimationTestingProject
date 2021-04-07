using System;
using System.Threading.Tasks;

namespace SchEstimationTestingProject.Core.Banks.InfrastructureServiceInterfaces
{
    public interface IBankServiceProvider
    {
        void Add(string bankName, IBankService bankProviderService);
        IBankService Get(string bankName);
    }
}
