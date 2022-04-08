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
    public class BudgetInfoBasedOnCenterRepository : BaseRepository<BudgetInfoBasedOnCenter>, IBudgetInfoBasedOnCenterRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;
        public BudgetInfoBasedOnCenterRepository(DMSAppDbContext dmsAppDBContext)
            : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }
        public async Task<List<BudgetInfoBasedOnCenter>> FetchBudgetInfoBasedOnCenter(int locId, int centerId, string purpose)
        {
            var result = await _dmsAppDBContext.BudgetInfoBasedOnCenter.Where(
                                        x=>x.LocationId== locId && 
                                        x.CenterId== centerId && 
                                        x.PurposeName.ToLower() == purpose.ToLower()).Select(p=> new BudgetInfoBasedOnCenter { 
                                                BudgetActivityName = p.BudgetActivityName,
                                                BudgetAmount=p.BudgetAmount
                                        })
            .ToListAsync<BudgetInfoBasedOnCenter>();

            return result;
        }
    }
}
