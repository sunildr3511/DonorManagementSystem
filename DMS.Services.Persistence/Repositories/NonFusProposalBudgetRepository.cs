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
   public class NonFusProposalBudgetRepository : BaseRepository<NonFusProposalBudget>, INonFusProposalBudgetRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;
        public NonFusProposalBudgetRepository(DMSAppDbContext dmsAppDBContext) :base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<List<NonFusProposalBudget>> GetListOfBudget(int proposalId)
        {
            var listOfNonFusProposalBudgetForDonor = await _dmsAppDBContext.NonFusProposalBudgetInfo
                                               .Where(x => x.ProposalId == proposalId).Select(p => p).ToListAsync<NonFusProposalBudget>();

            return listOfNonFusProposalBudgetForDonor;
        }
    }
}
