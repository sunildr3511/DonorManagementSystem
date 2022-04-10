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
    public class GetDonorBasedNonFusProposalQueryHandler : IRequestHandler<GetDonorBasedNonFusProposalQuery, List<DonorBasedProposalVM>>
    {
        private readonly IMapper _mapper;
         private readonly IDonorNonFusProposalRepository _donorNonFusProposalRepository;
        public GetDonorBasedNonFusProposalQueryHandler(IMapper mapper, IDonorNonFusProposalRepository donorNonFusProposalRepository)
        {
            _mapper = mapper;
            _donorNonFusProposalRepository = donorNonFusProposalRepository;
        }
        public async Task<List<DonorBasedProposalVM>> Handle(GetDonorBasedNonFusProposalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var listOfProposalsForDonor = await _donorNonFusProposalRepository.FetchNonFusProposalBasedOnDonorId(request.DonorId);

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
