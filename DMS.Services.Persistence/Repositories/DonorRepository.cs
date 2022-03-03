using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Persistence.Repositories
{
   public class DonorRepository : BaseRepository<Donor>, IDonorRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;

        public DonorRepository(DMSAppDbContext dmsAppDBContext) : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }
    }
}
