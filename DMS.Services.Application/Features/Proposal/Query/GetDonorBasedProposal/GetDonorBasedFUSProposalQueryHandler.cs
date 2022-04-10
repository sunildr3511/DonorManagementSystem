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
    public class GetDonorBasedFUSProposalQueryHandler : IRequestHandler<GetDonorBasedFUSProposalQuery, List<DonorBasedProposalVM>>
    {
        private readonly IMapper _mapper;
        private readonly IDonorFusProposalRepository _donorFUSProposalRepository;
        public GetDonorBasedFUSProposalQueryHandler(IMapper mapper, IDonorFusProposalRepository donorFUSProposalRepository)
        {
            _mapper = mapper;
            _donorFUSProposalRepository = donorFUSProposalRepository;
        }
        public async Task<List<DonorBasedProposalVM>> Handle(GetDonorBasedFUSProposalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listOfProposalsForDonor = await _donorFUSProposalRepository.FetchProposalBasedOnDonorId(request.DonorId);

                return _mapper.Map<List<DonorBasedProposalVM>>(listOfProposalsForDonor);
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
