using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Persistence
{
    public static class PersistentServiceRegistration
    {
        public static IServiceCollection AddPersistentService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DMSAppDbContext>(options => options.UseSqlServer
                                                              (configuration.GetConnectionString("DMSDBConnection")
                                                              ));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ISystemConfigurationRepository, SystemConfigurationRepository>();

            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddScoped<ICentreRepository, CentreRepository>();

            services.AddScoped<IDonorRepository, DonorRepository>();

            services.AddScoped<IKindDonorRepository, KindDonorRepository>();

            services.AddScoped<IStakeHolderRepository, StakeHolderRepository>();

            services.AddScoped<IBudgetInfoBasedOnCenterRepository, BudgetInfoBasedOnCenterRepository>();

            services.AddScoped<IDonorNonFusProposalRepository, DonorNonFusProposalRepository>();

            services.AddScoped<IDonorFusProposalRepository, DonorFusProposalRepository>();

            services.AddScoped<INonFusProposalBudgetRepository, NonFusProposalBudgetRepository>();

            services.AddScoped<IRoleInfoRepository, RoleInfoRepository>();

            services.AddScoped<IUserInfoRepository, UserInfoRepository>();

            services.AddScoped<IDonorCommentRepository, DonorCommentRepository>();

            services.AddScoped<IKindDonorCommentRepository, KindDonorCommentRepository>();

            return services;
        }
    }
}
