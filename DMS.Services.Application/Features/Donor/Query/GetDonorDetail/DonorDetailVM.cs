using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class DonorDetailVM
    {
        public int Id { get; set; }
        public string DonorId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string PanCard { get; set; }
        public string Category { get; set; }
        public string ReferedBy { get; set; }
        public string RelationShipManager { get; set; }
        public string SourceOfPayment { get; set; }
        public string Purpose { get; set; }
        public int Location { get; set; }
        public int Centre { get; set; }
        public string Comment { get; set; }
        public DateTime FollowUpDate { get; set; }

        public List<StakeHolderVM> StakeHolders { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DonationReceived { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }

        public int TypeId { get; set; }

        public int CategoryId { get; set; }

        public int SourceOfPaymentId { get; set; }

        public int PurposeId { get; set; }

        public int DonationReceivedId { get; set; }

        public List<DonorCommentVM> DonorComments { get; set; }

        public string Status { get; set; }
    }
}
