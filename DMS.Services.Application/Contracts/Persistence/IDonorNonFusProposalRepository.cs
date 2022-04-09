using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Application.Contracts.Persistence
{
   public interface IDonorNonFusProposalRepository : IAsyncRepository<NonFusProposal>
    {
        
    }
}
