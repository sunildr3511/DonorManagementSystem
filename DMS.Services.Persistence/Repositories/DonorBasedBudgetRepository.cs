using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Persistence.Repositories
{
    public class DonorBasedBudgetRepository : BaseRepository<DonorBasedBudgetInfo>, IDonorBasedBudgetRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;
        public DonorBasedBudgetRepository(DMSAppDbContext dmsAppDBContext) :base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }
    }
}
