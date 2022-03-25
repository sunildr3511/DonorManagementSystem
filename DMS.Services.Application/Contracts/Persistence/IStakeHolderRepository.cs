using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Application.Contracts.Persistence
{
   public interface IStakeHolderRepository : IAsyncRepository<StakeHolder>
    {
        Task<List<StakeHolder>> GetStakeHoldersForDonor(int donorId);
    }
}
