using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class KindDonorCreateCommand : IRequest<DonorVM>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DonationReceived { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }

        public int DonationReceivedId { get; set; }
    }
}
