using DMS.Services.Application.Features;
using DMS.Services.Domain.DataModel;
using DMS.Services.Domain.Entities;
using DMS.Services.Domain.RoleBasedDonors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Application.Contracts.Persistence
{
   public interface IDonorRepository : IAsyncRepository<Donor>
    {
        Task<int> GetMaxId();

        Task<List<DonorDM>> GetAllDonors(int loggedinUserId);

        Task<List<ReportingManagerDonorList>> FetchReportingManagerDonors(int loggedinUserId);
    }
}
