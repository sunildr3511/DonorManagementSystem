using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features.Donor
{
   public class ReportingManagerDonorListVM
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public int ReportingManagerCode { get; set; }

        public int DonorProfileCount { get; set; }

        public string ReportingManagerName { get; set; }
    }
}
