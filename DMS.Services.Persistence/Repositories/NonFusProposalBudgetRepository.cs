using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using MediatR;
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

        public async Task DeleteDonorProposals(int donorId)
        {
            var donorProposals = await _dmsAppDBContext.NonFusProposalBudgetInfo.Where(p => p.DonorId == donorId).Select(p => p).ToListAsync<NonFusProposalBudget>();

            _dmsAppDBContext.NonFusProposalBudgetInfo.RemoveRange(donorProposals);
            _dmsAppDBContext.SaveChanges();
        }

        public async Task DeleteNonFusProposalBudgets(int proposalId)
        {
            var nonFusProposalBudgets = await _dmsAppDBContext.NonFusProposalBudgetInfo.Where(p => p.ProposalId == proposalId).Select(p => p).ToListAsync<NonFusProposalBudget>();

            _dmsAppDBContext.NonFusProposalBudgetInfo.RemoveRange(nonFusProposalBudgets);
            _dmsAppDBContext.SaveChanges();
        }

        public async Task<List<NonFusProposalBudget>> GetListOfBudget(int proposalId)
        {
            var listOfNonFusProposalBudgetForDonor = await _dmsAppDBContext.NonFusProposalBudgetInfo
                                               .Where(x => x.ProposalId == proposalId).Select(p => p).ToListAsync<NonFusProposalBudget>();

            return listOfNonFusProposalBudgetForDonor;
        }

        public async Task<Unit> UpdateNonFusBudgetInfo(int proposalId, string activityName, double centerAmount, double budgetAmount)
        {
            string query = $"Update NonFusProposalBudgetInfo Set CenterAmount = {centerAmount} Where ProposalId = {proposalId} AND ActivityName= '{activityName}' AND BudgetAmount = {budgetAmount}";

            await _dmsAppDBContext.Database.ExecuteSqlRawAsync(query);

            return Unit.Value;
        }

       
    }
}
