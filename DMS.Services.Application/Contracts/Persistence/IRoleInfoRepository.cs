using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Contracts.Persistence
{
   public interface IRoleInfoRepository : IAsyncRepository<RoleInfo>
    {
    }
}
