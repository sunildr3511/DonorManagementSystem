using System;

namespace DMS.Services.Domain.Entities
{
    public class StakeHolderDTO
    {
        public string Salutation { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Company { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public bool DecisionMaker { get; set; }
    }
}
