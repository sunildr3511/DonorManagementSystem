using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class GetDonorBasedFUSProposalQuery : IRequest<List<DonorBasedProposalVM>>
    {
        public int DonorId { get; set; }
    }
}
