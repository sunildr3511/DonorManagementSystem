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
   public class DonorFusProposalRepository : BaseRepository<FusProposal>, IDonorFusProposalRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;
        public DonorFusProposalRepository(DMSAppDbContext dmsAppDBContext): base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<List<FusProposal>> FetchProposalBasedOnDonorId(int donorId)
        {
           var listOfProposalsForDonor=  await _dmsAppDBContext.FusProposalInfo
                                                .Where(x => x.DonorId == donorId).Select(p => p).ToListAsync<FusProposal>();

            return listOfProposalsForDonor;
        }

        public async Task DeleteDonorProposals(int donorId)
        {
            var donorProposals = await _dmsAppDBContext.FusProposalInfo.Where(p => p.DonorId == donorId).Select(p => p).ToListAsync<FusProposal>();

            _dmsAppDBContext.FusProposalInfo.RemoveRange(donorProposals);
            _dmsAppDBContext.SaveChanges();


        }
    }
}
