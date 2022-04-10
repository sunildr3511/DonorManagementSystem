using DMS.Services.Application.Features;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class GetNonFusProposalDetailQuery : IRequest<NonFusProposalDetailVM>
    {
        public int ProposalId { get; set; }
    }
}
