using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Application.Features;
using DMS.Services.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Persistence.Repositories
{
   public class DonorRepository : BaseRepository<Donor>, IDonorRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;

        public DonorRepository(DMSAppDbContext dmsAppDBContext) : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<List<Donor>> GetAllDonors()
        {
            var donorsInfo = await _dmsAppDBContext.DonorInfo.Select(p => new Donor {

                Id = p.Id,
                DonorId = p.DonorId,
                Type = p.Type,
                Name = p.Name,
                Location = p.Location,
                Centre = p.Centre,
                FollowUpDate = p.FollowUpDate,
                DonorType = p.DonorType

            }).ToListAsync<Donor>();

            return donorsInfo;
        }

        public async Task<int> GetMaxId()
        {
            var itemsExist = await _dmsAppDBContext.DonorInfo.AnyAsync();

            int maxDonorId = (!itemsExist) ? 1 : await _dmsAppDBContext.DonorInfo.MaxAsync(x => x.Id) + 1;

            return maxDonorId;
        }

        
    }
}
