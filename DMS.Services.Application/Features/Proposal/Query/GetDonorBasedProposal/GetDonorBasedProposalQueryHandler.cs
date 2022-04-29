using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using MediatR;
using System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
    public class GetDonorBasedProposalQueryHandler : IRequestHandler<GetDonorBasedProposalQuery, List<DonorBasedProposalVM>>
    {
        private readonly IMapper _mapper;
        private readonly IDonorFusProposalRepository _donorFUSProposalRepository;
        private readonly IDonorNonFusProposalRepository _donorNonFusProposalRepository;

        public GetDonorBasedProposalQueryHandler(IMapper mapper, IDonorFusProposalRepository donorFUSProposalRepository, IDonorNonFusProposalRepository donorNonFusProposalRepository)
        {
            _mapper = mapper;
            _donorNonFusProposalRepository = donorNonFusProposalRepository;
            _donorFUSProposalRepository = donorFUSProposalRepository;
        }
        public async Task<List<DonorBasedProposalVM>> Handle(GetDonorBasedProposalQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var listOfNonFusProposalsForDonor = await _donorNonFusProposalRepository.FetchNonFusProposalBasedOnDonorId(request.DonorId);

                List<DonorBasedProposalVM> listOfProposalsForDonor = _mapper.Map<List<DonorBasedProposalVM>>(listOfNonFusProposalsForDonor);

                var listOfFusProposalsForDonor = await _donorFUSProposalRepository.FetchProposalBasedOnDonorId(request.DonorId);

                listOfProposalsForDonor.AddRange(_mapper.Map<List<DonorBasedProposalVM>>(listOfFusProposalsForDonor));

                return listOfProposalsForDonor;
            }
            catch (Exception ex)
            {
                if (ex is Exceptions.ValidationException)
                    throw new Exception(string.Join(",", (ex as Exceptions.ValidationException).ValidationErrors));
                else
                    throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
