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
                Value = p.Value,
                Id=p.Id,
                IsActive= p.IsActive

            }).ToListAsync();

            SysConfigMasterData sysConfigMasterData = new SysConfigMasterData
            {
                Locations = results.Where(x => x.Name == "Location" && x.IsActive==true ).Select(p => new MasterData { Id = p.Id, Value = p.Value }),
                DonorType = results.Where(x => x.Name == "DonorType" && x.IsActive == true).Select(p => new MasterData { Id=p.Id,Value=p.Value }),
                DonorCategory = results.Where(x => x.Name == "DonorCategory" && x.IsActive == true).Select(p => new MasterData { Id = p.Id, Value = p.Value }),
                Salutation = results.Where(x => x.Name == "Salutation" && x.IsActive == true).Select(p => new MasterData { Id = p.Id, Value = p.Value}),
                SourceOfPayment = results.Where(x => x.Name == "SourceOfPayment" && x.IsActive == true).Select(p => new MasterData { Id = p.Id, Value = p.Value }),
                Purpose = results.Where(x => x.Name == "Purpose" && x.IsActive == true).Select(p => new MasterData { Id = p.Id, Value = p.Value}),
                Documents = results.Where(x => x.Name == "Documents" && x.IsActive == true).Select(p => new MasterData { Id = p.Id, Value = p.Value }),
                Roles = results.Where(x => x.Name == "Role" && x.IsActive == true).Select(p => new MasterData { Id = p.Id, Value = p.Value }),
                DonationReceived = results.Where(x=>x.Name == "DonationReceived" && x.IsActive == true).Select(p=> new MasterData { Id = p.Id, Value = p.Value })

            };

            return sysConfigMasterData;
        }
    }
}
