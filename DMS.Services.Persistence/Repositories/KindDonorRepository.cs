using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.DataModel;
using DMS.Services.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Persistence.Repositories
{
   public class KindDonorRepository : BaseRepository<KindDonor>,IKindDonorRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;

        public KindDonorRepository(DMSAppDbContext dmsAppDBContext) : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<List<KindDonorDM>> GetAllKindDonors(int loggedinUserId)
        {
            var kindDonorsInfo = await _dmsAppDBContext.KindDonorInfo.Where(x=>x.CreatedBy== loggedinUserId).Select(p => new KindDonorDM
            {

                Id = p.Id,
                DonorId = p.DonorId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                ContactNo = p.ContactNo,
                Email = p.Email,
                DonationReceived = p.DonationReceived,
                Quantity = p.Quantity,
                Description = p.Description,
                Address = p.Address,
                DonationReceivedId=p.DonationReceivedId,
                Status = _dmsAppDBContext.KindDonorCommentInfo.OrderByDescending(x=>x.Id).Where(y=>y.DonorId == p.Id).FirstOrDefault().Status
            }).ToListAsync<KindDonorDM>();

            return kindDonorsInfo;
        }

        public async Task<int> GetMaxId()
        {
            var itemsExist = await _dmsAppDBContext.KindDonorInfo.AnyAsync();

            int maxDonorId = (!itemsExist) ? 1 : await _dmsAppDBContext.KindDonorInfo.MaxAsync(x => x.Id) + 1;

            return maxDonorId;
        }
    }
}
