using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchEstimationTestingProject.Core.Common.RepositoryInterfaces;
using SchEstimationTestingProject.Core.Users.RepositoryInterfaces;
using SchEstimationTestingProject.Core.Wallets.RepositoryInterfaces;
using SchEstimationTestingProject.Infrastructure.Users.Repositories;
using SchEstimationTestingProject.Infrastructure.Wallets.Repositories;

namespace SchEstimationTestingProject.Infrastructure.Common.Data
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly EfCoreDbContext _context;
        private IDbContextTransaction _transaction;

        public EfCoreUnitOfWork(EfCoreDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(context);
            WalletRepository = new WalletRepository(context);
        }

        public IUserRepository UserRepository { get; }

        public IWalletRepository WalletRepository { get; }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public Task CommitTransactionAsync()
        {
            return _transaction.CommitAsync();
        }

        public Task RollbackTransactionAsync()
        {
            return _transaction.RollbackAsync();
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException duce)
            {
                throw duce;
            }
            catch (DbUpdateException due)
            {
                throw due;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {

            if (_disposedValue)
            {
                return;
            }
            if (disposing)
            {
                _transaction?.Dispose();
                _context.Dispose();
            }
            _disposedValue = true;
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
    }
}
