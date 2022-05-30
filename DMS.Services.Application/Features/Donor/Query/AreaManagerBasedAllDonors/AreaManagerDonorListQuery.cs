using DMS.Services.Application.Features.Donor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class AreaManagerDonorListQuery : IRequest<List<AreaManagerDonorListVM>>
    {
        public int LoggedInUserId { get; set; }
    }
}
