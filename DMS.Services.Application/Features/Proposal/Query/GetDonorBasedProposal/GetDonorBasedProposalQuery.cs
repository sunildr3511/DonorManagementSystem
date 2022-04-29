using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class GetDonorBasedProposalQuery : IRequest<List<DonorBasedProposalVM>>
    {
        public int DonorId { get; set; }
    }
}
