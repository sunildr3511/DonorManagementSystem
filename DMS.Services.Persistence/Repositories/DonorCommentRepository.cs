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
   public class DonorCommentRepository : BaseRepository<DonorCommentInfo>, IDonorCommentRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;

        public DonorCommentRepository(DMSAppDbContext dmsAppDBContext) : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<List<DonorCommentInfo>> GetCommentsForDonor(int donorId)
        {
            var donorComments = await _dmsAppDBContext.DonorCommentInfo.Where(x => x.DonorId == donorId).Select(p => p).ToListAsync<DonorCommentInfo>();

            return donorComments;
        }
       
    }
}
