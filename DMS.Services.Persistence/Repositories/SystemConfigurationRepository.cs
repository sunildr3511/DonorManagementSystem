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

        public async Task<string> FetchNameBasedOnId(int id)
        {
            var result = await _dmsAppDBContext.SystemConfiguration.SingleOrDefaultAsync(x => x.Id == id);

            return result.Value;
        }

        public async Task<SysConfigMasterData> GetSystemConfiguration()
        {
            var results = await _dmsAppDBContext.SystemConfiguration.Select(p => new
            {
                Name = p.Name,
                Value = p.Value,
                Id=p.Id,
                IsActive= p.IsActive

            }).ToListAsync();

            SysConfigMasterData sysConfigMasterData = new SysConfigMasterData
            {
                Locations = results.Where(x => x.Name == "Location").Select(p => new MasterData { Id = p.Id, Value = p.Value, IsActive =p.IsActive }),
                DonorType = results.Where(x => x.Name == "DonorType").Select(p => new MasterData { Id=p.Id,Value=p.Value, IsActive = p.IsActive }),
                DonorCategory = results.Where(x => x.Name == "DonorCategory").Select(p => new MasterData { Id = p.Id, Value = p.Value, IsActive = p.IsActive }),
                Salutation = results.Where(x => x.Name == "Salutation").Select(p => new MasterData { Id = p.Id, Value = p.Value, IsActive = p.IsActive }),
                SourceOfPayment = results.Where(x => x.Name == "SourceOfPayment").Select(p => new MasterData { Id = p.Id, Value = p.Value, IsActive = p.IsActive }),
                Purpose = results.Where(x => x.Name == "Purpose").Select(p => new MasterData { Id = p.Id, Value = p.Value, IsActive = p.IsActive }),
                Documents = results.Where(x => x.Name == "Documents").Select(p => new MasterData { Id = p.Id, Value = p.Value, IsActive = p.IsActive }),
                Roles = results.Where(x => x.Name == "Role").Select(p => new MasterData { Id = p.Id, Value = p.Value, IsActive = p.IsActive }),
                DonationReceived = results.Where(x=>x.Name == "DonationReceived").Select(p=> new MasterData { Id = p.Id, Value = p.Value, IsActive = p.IsActive }),
                UserRoles = results.Where(x => x.Name == "UserRoles" && x.Value !="admin").Select(p => new MasterData { Id = p.Id, Value = p.Value, IsActive = p.IsActive })

            };

            return sysConfigMasterData;
        }
    }
}
