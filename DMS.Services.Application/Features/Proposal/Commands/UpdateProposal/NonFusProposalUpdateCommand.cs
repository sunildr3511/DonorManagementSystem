using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class NonFusProposalUpdateCommand : IRequest
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public string DonorProspectId { get; set; }
        public string DonorName { get; set; }
        public string Purpose { get; set; }
        public string ProposalName { get; set; }
        public int LocationId { get; set; }
        public int CenterId { get; set; }
        public int NumberOfUnit { get; set; }
        public string Unit { get; set; }
        public DateTime PeriodOfDonationFrom { get; set; }
        public DateTime PeriodofDonationTo { get; set; }
        public double Amount { get; set; }
        public string NarrativeReportFrequency { get; set; }
        public string UtilizationReportFrequency { get; set; }
        public List<NonFusProposalBudgetVM> ListOfBudget { get; set; }
    }
}
