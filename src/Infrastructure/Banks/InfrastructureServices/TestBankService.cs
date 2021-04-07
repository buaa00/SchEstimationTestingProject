using System;
using System.Threading.Tasks;
using SchEstimationTestingProject.Core.Banks.DTOs;
using SchEstimationTestingProject.Core.Banks.InfrastructureServiceInterfaces;

namespace SchEstimationTestingProject.Infrastructure.Banks.InfrastructureServices
{
    public class DummyBankService : IBankService
    {
        public Task<CheckStatusResDTO> CheckStatusAsync(string jmbg, string pin)
        {
            return Task.FromResult(new CheckStatusResDTO()
            {
                Success = true,
                Message = ""
            });
        }
    }
}
