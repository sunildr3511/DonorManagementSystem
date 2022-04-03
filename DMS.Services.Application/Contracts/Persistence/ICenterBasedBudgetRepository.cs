using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Application.Contracts.Persistence
{
   public interface ICenterBasedBudgetRepository
    {
        Task<List<CenterBasedBudgetInfo>> FetchCenterBasedBudgetInfo(int locId,int centerId,string purpose);
    }
}
