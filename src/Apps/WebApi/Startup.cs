using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SchEstimationTestingProject.Core.Banks.InfrastructureServiceInterfaces;
using SchEstimationTestingProject.Core.Common.RepositoryInterfaces;
using SchEstimationTestingProject.Core.Users.ApplicationServices;
using SchEstimationTestingProject.Core.Users.RepositoryInterfaces;
using SchEstimationTestingProject.Core.Wallets.RepositoryInterfaces;
using SchEstimationTestingProject.Infrastructure.Banks.InfrastructureServices;
using SchEstimationTestingProject.Infrastructure.Common.Data;
using SchEstimationTestingProject.Infrastructure.Users.Repositories;
using SchEstimationTestingProject.Infrastructure.Wallets.Repositories;

namespace SchEstimationTestingProject.Apps.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<EfCoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration["SqlServer:ConnectionString"]);
            });

            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IBankServiceProvider, BankServiceProvider>(sp =>
            {
                var bsp = new BankServiceProvider();
                bsp.Add("dummy", new DummyBankService());
                return bsp;
            });
            services.AddScoped<UserService>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchEstimationTestingProject.Apps.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchEstimationTestingProject.Apps.WebApi v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
