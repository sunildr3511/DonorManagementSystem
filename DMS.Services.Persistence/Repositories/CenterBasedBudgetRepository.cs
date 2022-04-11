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
        public async Task<List<BudgetInfoBasedOnCenter>> FetchBudgetInfoBasedOnCenter(int locId, int centerId, int purposeId)
        {

            string purposeName = FetchPurposeNameBasedOnId(purposeId);

            var result = await _dmsAppDBContext.BudgetInfoBasedOnCenter.Where(
                                        x=>x.LocationId== locId && 
                                        x.CenterId== centerId && 
                                        x.PurposeName.ToLower() == purposeName.ToLower()).Select(p=> new BudgetInfoBasedOnCenter { 
                                                BudgetActivityName = p.BudgetActivityName,
                                                BudgetAmount=p.BudgetAmount
                                        })
            .ToListAsync<BudgetInfoBasedOnCenter>();

            return result;
        }

        private string FetchPurposeNameBasedOnId(int purposeId)
        {
            string purposeName = string.Empty;
            switch(purposeId)
            {
                case 1:
                    purposeName = "Capex";
                    break;
                case 2:
                    purposeName = "Opex";
                    break;
                case 4:
                    purposeName = "Sustainability";
                    break;
                case 5:
                    purposeName = "Corpus";
                    break;
                default:
                    purposeName = "Capex";
                    break;
            }
            return purposeName;
        }
    }
}
