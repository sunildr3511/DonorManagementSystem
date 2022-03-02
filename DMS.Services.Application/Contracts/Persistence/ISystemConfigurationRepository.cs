using DMS.Services.Domain.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Application.Contracts.Persistence
{
    public interface ISystemConfigurationRepository
    {
        Task<SysConfigMasterData> GetSystemConfiguration();
    }
}
