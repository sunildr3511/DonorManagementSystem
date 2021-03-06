using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Application.Contracts.Persistence
{
   public interface IDonorFusProposalRepository : IAsyncRepository<FusProposal>
    {
        Task<List<FusProposal>> FetchProposalBasedOnDonorId(int donorId);

        Task DeleteDonorProposals(int donorId);
    }
}
