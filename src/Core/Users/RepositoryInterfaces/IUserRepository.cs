using System;
using System.Threading.Tasks;
using SchEstimationTestingProject.Core.Common.RepositoryInterfaces;
using SchEstimationTestingProject.Core.Users.Entities;

namespace SchEstimationTestingProject.Core.Users.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task StoreAsync(User user);
        Task<User> GetByIdAsync(string userId);
        Task<User> GetByJMBGAsync(string userJMBG);
    }
}
