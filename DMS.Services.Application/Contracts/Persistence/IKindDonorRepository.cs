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

        Task<List<KindDonor>> GetAllKindDonors(int loggedinUserId);
    }
}
