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
    public class DonorNonFusProposalRepository : BaseRepository<NonFusProposal>, IDonorNonFusProposalRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;
        public DonorNonFusProposalRepository(DMSAppDbContext dmsAppDBContext) :base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<List<NonFusProposal>> FetchNonFusProposalBasedOnDonorId(int donorId)
        {
            var listOfProposalsForDonor = await _dmsAppDBContext.NonFusProposalInfo
                                                .Where(x => x.DonorId == donorId).Select(p => p).ToListAsync<NonFusProposal>();

            return listOfProposalsForDonor;
        }
    }
}
