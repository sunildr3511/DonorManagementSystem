using DMS.Services.Domain.DataModel;
using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Application.Contracts.Persistence
{
   public interface IKindDonorRepository : IAsyncRepository<KindDonor>
    {
        Task<int> GetMaxId();

        Task<List<KindDonorDM>> GetAllKindDonors(int loggedinUserId);
    }
}
