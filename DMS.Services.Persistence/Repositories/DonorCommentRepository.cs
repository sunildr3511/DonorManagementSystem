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
   public class DonorCommentRepository : BaseRepository<DonorCommentInfo>, IDonorCommentRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;

        public DonorCommentRepository(DMSAppDbContext dmsAppDBContext) : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<List<DonorCommentInfoDM>> GetCommentsForDonor(int donorId)
        {
            var donorComments = await (from t1 in _dmsAppDBContext.DonorCommentInfo
                                           join t2 in _dmsAppDBContext.UserInfo
                                           on t1.CommentBy equals t2.Id
                                           where t1.DonorId == donorId
                                           select new DonorCommentInfoDM
                                           {
                                               Id = t1.Id,
                                               DonorId = t1.DonorId,
                                               IsApproved = t1.IsApproved,
                                               Comments = t1.Comments,
                                               CommentBy = t1.CommentBy,
                                               CommentByName = t2.Name
                                           }).ToListAsync<DonorCommentInfoDM>();

            return donorComments;
        }
       
    }
}
