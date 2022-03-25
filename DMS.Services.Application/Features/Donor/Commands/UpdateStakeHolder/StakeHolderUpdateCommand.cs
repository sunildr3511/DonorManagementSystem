using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
    public class  StakeHolderUpdateCommand : IRequest
    {
        public int Id { get; set; }

        public int DonorId { get; set; }

        public string DecisionMakingRole { get; set; }
        public string DonorRelationShip { get; set; }
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
