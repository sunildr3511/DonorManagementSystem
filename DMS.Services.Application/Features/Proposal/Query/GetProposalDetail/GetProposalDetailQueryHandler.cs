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
    public class GetProposalDetailQueryHandler : IRequestHandler<GetFUSProposalDetailQuery, FUSProposalDetailVM>
    {
        private readonly IMapper _mapper;
        private readonly IDonorFUSProposalRepository _donorFUSProposalRepository;
        public GetProposalDetailQueryHandler(IMapper mapper, IDonorFUSProposalRepository donorFUSProposalRepository)
        {
            _mapper = mapper;
            _donorFUSProposalRepository = donorFUSProposalRepository;
        }
        public async Task<FUSProposalDetailVM> Handle(GetFUSProposalDetailQuery request, CancellationToken cancellationToken)
        {
            var fusProposalInfo = await _donorFUSProposalRepository.GetByIdAsync(request.ProposalId);

            if (fusProposalInfo == null)
            {
                throw new Exceptions.NotFoundException(nameof(Domain.Entities.FamilyUnitSponsorProposal), Convert.ToString(request.ProposalId));
            }

           var mappedfusProposalInfo = _mapper.Map<FUSProposalDetailVM>(fusProposalInfo);

            return mappedfusProposalInfo;
        }
    }
}
