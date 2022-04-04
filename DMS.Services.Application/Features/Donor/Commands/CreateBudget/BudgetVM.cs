using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class BudgetVM
    {
        public int DonorId { get; set; }
        public string DonorName { get; set; }
        public string PurposeName { get; set; }
        public int LocationId { get; set; }
        public int CenterId { get; set; }
        public int NumberOfUnit { get; set; }
        public string Unit { get; set; }
        public bool Signage { get; set; }
        public double Attribute1 { get; set; }
        public double Attribute2 { get; set; }
        public double Attribute3 { get; set; }
        public double Attribute4 { get; set; }
        public double Attribute5 { get; set; }
        public double Attribute6 { get; set; }
        public double Attribute7 { get; set; }
        public double Attribute8 { get; set; }
        public double Attribute9 { get; set; }
        public double Attribute10 { get; set; }
        public double Attribute11 { get; set; }
        public double Attribute12 { get; set; }
        public double Attribute13 { get; set; }

        public DateTime PeriodofDonationFrom { get; set; }
        public DateTime PeriodofDonationTo { get; set; }
        public double Amount { get; set; }
        public string NarrativeReportFrequency { get; set; }
        public string UtilizationReportFrequency { get; set; }
    }
}
