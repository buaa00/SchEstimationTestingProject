using System;
using System.Threading.Tasks;
using SchEstimationTestingProject.Core.Users.Entities;

namespace SchEstimationTestingProject.Core.Users.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task SaveAsync(User user);
        Task<User> GetByIdAsync(string userId);
        Task<User> GetByJMBGAsync(string userJMBG);
    }
}
