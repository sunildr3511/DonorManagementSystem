using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class DonorCreateCommand : IRequest<DonorVM>
    {
        //public int Id { get; set; }
      //  public string DonorId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string PanCard { get; set; }
        public string Category { get; set; }
        public string ReferedBy { get; set; }
        public string RelationShipManager { get; set; }
        public string SourceOfPayment { get; set; }
        public string Purpose { get; set; }
        public string Location { get; set; }
        public string Centre { get; set; }
        public string Comment { get; set; }
        public DateTime FollowUpDate { get; set; }
 
    }
}
