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
    public class CenterBasedBudgetRepository : BaseRepository<CenterBasedBudgetInfo>, ICenterBasedBudgetRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;
        public CenterBasedBudgetRepository(DMSAppDbContext dmsAppDBContext)
            : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }
        public async Task<List<CenterBasedBudgetInfo>> FetchCenterBasedBudgetInfo(int locId, int centerId, string purpose)
        {
            var result = await _dmsAppDBContext.CenterBasedBudgetInfo.Where(
                                        x=>x.LocationId== locId && 
                                        x.CenterId== centerId && 
                                        x.PurposeName.ToLower() == purpose.ToLower()).Select(p=> new CenterBasedBudgetInfo { 
                                                BudgetActivityName = p.BudgetActivityName,
                                                BudgetAmount=p.BudgetAmount
                                        })
            .ToListAsync<CenterBasedBudgetInfo>();

            return result;
        }
    }
}
