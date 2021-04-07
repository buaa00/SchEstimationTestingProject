using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchEstimationTestingProject.Core.Wallets.Entities;
using SchEstimationTestingProject.Core.Wallets.RepositoryInterfaces;
using SchEstimationTestingProject.Infrastructure.Common.Data;

namespace SchEstimationTestingProject.Infrastructure.Wallets.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly EfCoreDbContext _context;

        public WalletRepository(EfCoreDbContext context)
        {
            _context = context;
        }

        public Task<Wallet> GetByIdAsync(string walletId)
        {
            return _context.Wallets.SingleOrDefaultAsync(w => w.Id == walletId);
        }

        public Task<Wallet> GetByJMBGAsync(string userJMBG)
        {
            return _context.Wallets.Join(
                _context.Users,
                w => w.OwnerId,
                u => u.Id,
                (w, u) => new
                {
                    Wallet = w,
                    JMBG = u.Informations.JMBG
                }
                ).Where(x => x.JMBG == userJMBG).Select(x => x.Wallet).FirstOrDefaultAsync();
        }

        public async Task StoreAsync(Wallet wallet)
        {
            await _context.Wallets.AddAsync(wallet);
        }
    }
}
