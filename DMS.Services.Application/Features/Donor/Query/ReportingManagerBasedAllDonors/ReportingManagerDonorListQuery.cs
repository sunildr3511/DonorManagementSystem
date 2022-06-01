using DMS.Services.Application.Features.Donor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class ReportingManagerDonorListQuery : IRequest<List<ReportingManagerDonorListVM>>
    {
        public int LoggedInUserId { get; set; }
    }
}
