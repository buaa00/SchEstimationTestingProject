using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchEstimationTestingProject.Core.Users.Entities;
using SchEstimationTestingProject.Core.Users.RepositoryInterfaces;
using SchEstimationTestingProject.Infrastructure.Common.Data;

namespace SchEstimationTestingProject.Infrastructure.Users.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EfCoreDbContext _context;

        public UserRepository(EfCoreDbContext context)
        {
            _context = context;
        }

        public Task<User> GetByIdAsync(string userId)
        {
            return _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
        }

        public Task<User> GetByJMBGAsync(string userJMBG)
        {
            return _context.Users.SingleOrDefaultAsync(u => u.Informations.JMBG == userJMBG);
        }

        public async Task StoreAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
    }
}
