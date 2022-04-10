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
    public class GetNonFusProposalDetailQueryHandler : IRequestHandler<GetNonFusProposalDetailQuery, NonFusProposalDetailVM>
    {
        private readonly IMapper _mapper;
        private readonly IDonorNonFusProposalRepository _donorNonFusProposalRepository;
        private readonly INonFusProposalBudgetRepository _nonFusProposalBudgetRepository;
        public GetNonFusProposalDetailQueryHandler(IMapper mapper, IDonorNonFusProposalRepository donorNonFusProposalRepository, INonFusProposalBudgetRepository nonFusProposalBudgetRepository)
        {
            _mapper = mapper;
            _donorNonFusProposalRepository = donorNonFusProposalRepository;
            _nonFusProposalBudgetRepository = nonFusProposalBudgetRepository;
        }
        public async Task<NonFusProposalDetailVM> Handle(GetNonFusProposalDetailQuery request, CancellationToken cancellationToken)
        {
            var nonfusProposalInfo = await _donorNonFusProposalRepository.GetByIdAsync(request.ProposalId);

            if (nonfusProposalInfo == null)
            {
                throw new Exceptions.NotFoundException(nameof(Domain.Entities.NonFusProposal), Convert.ToString(request.ProposalId));
            }

            var mappedNonfusProposalInfo = _mapper.Map<NonFusProposalDetailVM>(nonfusProposalInfo);

            var listOfNonFusProposalBudgetBasedOnDonor = await _nonFusProposalBudgetRepository.GetListOfBudget(request.ProposalId);

            mappedNonfusProposalInfo.ListOfBudget = _mapper.Map<List<NonFusProposalBudgetVM>>(listOfNonFusProposalBudgetBasedOnDonor);

            return mappedNonfusProposalInfo;
        }
    }
}
