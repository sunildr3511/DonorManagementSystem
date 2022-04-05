using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Persistence.Repositories
{
    public class DonorBasedBudgetRepository : BaseRepository<DonorBasedBudgetInfo>, IDonorBasedBudgetRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;
        public DonorBasedBudgetRepository(DMSAppDbContext dmsAppDBContext) :base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<List<DonorBasedBudgetInfo>> FetchDonorBasedProposals(int donorId)
        {
            var result = await _dmsAppDBContext.DonorBasedBudgetInfo.Where(x => x.DonorId == donorId).Select(p=>p).ToListAsync<DonorBasedBudgetInfo>();

            return result;
        }
    }
}
