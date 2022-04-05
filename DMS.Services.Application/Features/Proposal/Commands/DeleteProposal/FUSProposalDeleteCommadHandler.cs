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
    public class FUSProposalDeleteCommadHandler : IRequestHandler<FUSProposalDeleteCommad>
    {
        private readonly IMapper _mapper;
        private readonly IDonorFUSProposalRepository _donorFUSProposalRepository;
        public FUSProposalDeleteCommadHandler(IMapper mapper, IDonorFUSProposalRepository donorFUSProposalRepository)
        {
            _mapper = mapper;
            _donorFUSProposalRepository = donorFUSProposalRepository;
        }
        public async Task<Unit> Handle(FUSProposalDeleteCommad request, CancellationToken cancellationToken)
        {
            try
            {
                var fusProposalToDelete = await _donorFUSProposalRepository.GetByIdAsync(request.Id);

                if (fusProposalToDelete == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.FamilyUnitSponsorProposal), Convert.ToString(request.Id));
                }

                _mapper.Map(request, fusProposalToDelete, typeof(FUSProposalDeleteCommad), typeof(Domain.Entities.FamilyUnitSponsorProposal));

                await _donorFUSProposalRepository.DeleteAsync(fusProposalToDelete);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
