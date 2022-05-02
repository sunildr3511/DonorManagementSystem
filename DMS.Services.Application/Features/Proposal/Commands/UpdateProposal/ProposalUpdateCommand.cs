using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
    public class ProposalUpdateCommand : IRequest
    {
        public FusProposalUpdateCommad FusProposalUpdateCommad { get; set; }

        public NonFusProposalUpdateCommand NonFusProposalUpdateCommand { get; set; }
    }
}
