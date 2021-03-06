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
    public class FusProposalDeleteCommadHandler : IRequestHandler<FusProposalDeleteCommad>
    {
        private readonly IMapper _mapper;
        private readonly IDonorFusProposalRepository _donorFUSProposalRepository;
        public FusProposalDeleteCommadHandler(IMapper mapper, IDonorFusProposalRepository donorFUSProposalRepository)
        {
            _mapper = mapper;
            _donorFUSProposalRepository = donorFUSProposalRepository;
        }
        public async Task<Unit> Handle(FusProposalDeleteCommad request, CancellationToken cancellationToken)
        {
            try
            {
                var fusProposalToDelete = await _donorFUSProposalRepository.GetByIdAsync(request.Id);

                if (fusProposalToDelete == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.FusProposal), Convert.ToString(request.Id));
                }

                _mapper.Map(request, fusProposalToDelete, typeof(FusProposalDeleteCommad), typeof(Domain.Entities.FusProposal));

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
