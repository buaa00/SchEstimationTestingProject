using System;
using Microsoft.EntityFrameworkCore;
using SchEstimationTestingProject.Core.Users.Entities;
using SchEstimationTestingProject.Core.Wallets.Entities;

namespace SchEstimationTestingProject.Infrastructure.Common.Data
{
    public class EfCoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }


        public EfCoreDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().OwnsOne(r => r.Informations);
        }
    }
}
