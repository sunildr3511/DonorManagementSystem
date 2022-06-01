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
   public class KindDonorCommentRepository : BaseRepository<KindDonorCommentInfo>, IKindDonorCommentRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;

        public KindDonorCommentRepository(DMSAppDbContext dmsAppDBContext) : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<List<KindDonorCommentInfo>> GetCommentsForDonor(int donorId)
        {
            var kindDonorComments = await _dmsAppDBContext.KindDonorCommentInfo.Where(x => x.DonorId == donorId).Select(p => p).ToListAsync<KindDonorCommentInfo>();

            return kindDonorComments;
        }
    }
}
