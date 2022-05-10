using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Persistence.Repositories
{
   public class RoleInfoRepository : BaseRepository<RoleInfo>, IRoleInfoRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;
        public RoleInfoRepository(DMSAppDbContext dmsAppDBContext) : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }
    }
}
