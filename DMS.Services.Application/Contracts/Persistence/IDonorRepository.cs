﻿using DMS.Services.Application.Features;
using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Application.Contracts.Persistence
{
   public interface IDonorRepository : IAsyncRepository<Donor>
    {
        Task<int> GetMaxId();

        Task<List<Donor>> GetAllDonors();
    }
}
