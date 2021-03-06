using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class FusProposalUpdateCommad : IRequest
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public string DonorProspectId { get; set; }
        public string DonorName { get; set; }
        public string Purpose { get; set; }
        public int LocationId { get; set; }
        public int CenterId { get; set; }
        public int NumberOfUnit { get; set; }
        public string Unit { get; set; }
        public bool Singage { get; set; }
        public DateTime PeriodOfDonationFrom { get; set; }
        public DateTime PeriodofDonationTo { get; set; }
        public double Amount { get; set; }
        public string FrequencyOfNarrativeReport { get; set; }
        public string FrequencyOfUtilizationCertificate { get; set; }

        public int PurposeId { get; set; }
    }
}
