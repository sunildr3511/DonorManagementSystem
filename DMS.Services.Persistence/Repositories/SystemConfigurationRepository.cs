using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using DMS.Services.Domain.MasterEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Persistence.Repositories
{
    public class SystemConfigurationRepository : BaseRepository<SystemConfiguration>, ISystemConfigurationRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;
        public SystemConfigurationRepository(DMSAppDbContext dmsAppDBContext) : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<SysConfigMasterData> GetSystemConfiguration()
        {
            var results = await _dmsAppDBContext.SystemConfiguration.Select(p => new
            {
                Name = p.Name,
                Value = p.Value
            }).ToListAsync();

            SysConfigMasterData sysConfigMasterData = new SysConfigMasterData
            {
                DonorType = results.Where(x => x.Name == "DonorType").Select(p => p.Value),
                DonorCategory = results.Where(x => x.Name == "DonorCategory").Select(p => p.Value),
                Salutation = results.Where(x => x.Name == "Salutation").Select(p => p.Value),
                SourceOfPayment = results.Where(x => x.Name == "SourceOfPayment").Select(p => p.Value),
                Purpose = results.Where(x => x.Name == "Purpose").Select(p => p.Value),
                Documents = results.Where(x => x.Name == "Documents").Select(p => p.Value),
                Roles = results.Where(x => x.Name == "Role").Select(p => p.Value)

            };

            return sysConfigMasterData;
        }
    }
}
