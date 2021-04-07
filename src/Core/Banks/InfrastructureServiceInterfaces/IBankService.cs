using System;
using System.Threading.Tasks;
using SchEstimationTestingProject.Core.Banks.DTOs;

namespace SchEstimationTestingProject.Core.Banks.InfrastructureServiceInterfaces
{
    public interface IBankService
    {
        Task<CheckStatusResDTO> CheckStatusAsync(string jmbg, string pin);
    }
}
