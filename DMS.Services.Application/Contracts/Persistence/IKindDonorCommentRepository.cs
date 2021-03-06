using DMS.Services.Domain.DataModel;
using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Application.Contracts.Persistence
{
   public interface IKindDonorCommentRepository : IAsyncRepository<KindDonorCommentInfo>
    {
        Task<List<KindDonorCommentInfoDM>> GetCommentsForDonor(int donorId);
    }
}
