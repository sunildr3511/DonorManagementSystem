using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class GetFUSProposalDetailQuery : IRequest<FUSProposalDetailVM>
    {
        public int ProposalId { get; set; }
    }
}
