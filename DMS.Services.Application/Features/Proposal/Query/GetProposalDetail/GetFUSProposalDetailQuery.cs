using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class GetFusProposalDetailQuery : IRequest<FusProposalDetailVM>
    {
        public int ProposalId { get; set; }
    }
}
