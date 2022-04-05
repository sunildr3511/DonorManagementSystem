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
   public class DonorFUSProposalRepository : BaseRepository<FamilyUnitSponsorProposal>, IDonorFUSProposalRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;
        public DonorFUSProposalRepository(DMSAppDbContext dmsAppDBContext): base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<List<FamilyUnitSponsorProposal>> FetchProposalBasedOnDonorId(int donorId)
        {
           var listOfProposalsForDonor=  await _dmsAppDBContext.DonorFamilyUnitSponsorShipProposal
                                                .Where(x => x.DonorId == donorId).Select(p => p).ToListAsync<FamilyUnitSponsorProposal>();

            return listOfProposalsForDonor;
        }
    }
}
