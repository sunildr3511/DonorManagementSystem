using DMS.Services.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Application.Contracts.Persistence
{
    public interface INonFusProposalBudgetRepository : IAsyncRepository<NonFusProposalBudget>
    {
        Task<List<NonFusProposalBudget>> GetListOfBudget(int proposalId);

        Task<Unit> UpdateNonFusBudgetInfo(int proposalId, string activityName, double centerAmount, double budgetAmount);

        Task DeleteNonFusProposalBudgets(int proposalId);

        Task DeleteDonorProposals(int donorId);
    }
}
