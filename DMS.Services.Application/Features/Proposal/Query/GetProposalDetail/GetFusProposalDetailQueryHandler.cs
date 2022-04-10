using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
    public class GetFusProposalDetailQueryHandler : IRequestHandler<GetFusProposalDetailQuery, FusProposalDetailVM>
    {
        private readonly IMapper _mapper;
        private readonly IDonorFusProposalRepository _donorFUSProposalRepository;
        public GetFusProposalDetailQueryHandler(IMapper mapper, IDonorFusProposalRepository donorFUSProposalRepository)
        {
            _mapper = mapper;
            _donorFUSProposalRepository = donorFUSProposalRepository;
        }
        public async Task<FusProposalDetailVM> Handle(GetFusProposalDetailQuery request, CancellationToken cancellationToken)
        {
            var fusProposalInfo = await _donorFUSProposalRepository.GetByIdAsync(request.ProposalId);

            if (fusProposalInfo == null)
            {
                throw new Exceptions.NotFoundException(nameof(Domain.Entities.FamilyUnitSponsorProposal), Convert.ToString(request.ProposalId));
            }

           var mappedfusProposalInfo = _mapper.Map<FusProposalDetailVM>(fusProposalInfo);

            return mappedfusProposalInfo;
        }
    }
}
