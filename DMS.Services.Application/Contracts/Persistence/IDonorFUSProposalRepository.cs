using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Application.Contracts.Persistence
{
   public interface IDonorFUSProposalRepository : IAsyncRepository<FamilyUnitSponsorProposal>
    {
        Task<List<FamilyUnitSponsorProposal>> FetchProposalBasedOnDonorId(int donorId);

        Task DeleteDonorProposals(int donorId);
    }
}
