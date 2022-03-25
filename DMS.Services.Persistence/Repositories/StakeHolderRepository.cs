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
    public class StakeHolderRepository : BaseRepository<StakeHolder>, IStakeHolderRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;

        public StakeHolderRepository(DMSAppDbContext dmsAppDBContext) : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task DeleteDonorStakeHolders(int donorId)
        {
            var stakeHolders = await _dmsAppDBContext.StakeHolderInfo.Where(p => p.DonorId == donorId).Select(p => p).ToListAsync<StakeHolder>();

             _dmsAppDBContext.StakeHolderInfo.RemoveRange(stakeHolders);
            _dmsAppDBContext.SaveChanges();


        }

        public async Task<List<StakeHolder>> GetStakeHoldersForDonor(int donorId)
        {
            var stakeHolders = await _dmsAppDBContext.StakeHolderInfo.Where(x=>x.DonorId == donorId).Select(p=>p).ToListAsync<StakeHolder>();

            return stakeHolders;
        }
    }
}
