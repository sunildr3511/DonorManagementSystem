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
    public class ProposalDeleteCommadHandler : IRequestHandler<ProposalDeleteCommad>
    {
        private readonly IMapper _mapper;
        private readonly IDonorFusProposalRepository _donorFUSProposalRepository;
        private FusProposalDeleteCommadHandler _fusProposalDeleteCommadHandler;

        private readonly IDonorNonFusProposalRepository _donorNonFUSProposalRepository;
        private readonly INonFusProposalBudgetRepository _nonFusProposalBudgetRepository;
        private NonFusProposalDeleteCommadHandler _nonFusProposalDeleteCommadHandler;
        public ProposalDeleteCommadHandler(IMapper mapper, IDonorFusProposalRepository donorFUSProposalRepository, IDonorNonFusProposalRepository donorNonFUSProposalRepository, INonFusProposalBudgetRepository nonFusProposalBudgetRepository)
        {
            _mapper = mapper;
            _donorFUSProposalRepository = donorFUSProposalRepository;
            _donorNonFUSProposalRepository = donorNonFUSProposalRepository;
            _nonFusProposalBudgetRepository = nonFusProposalBudgetRepository;
        }
        public async Task<Unit> Handle(ProposalDeleteCommad request, CancellationToken cancellationToken)
        {
            try
            {

                if(request.ProposalTypeId==1)
                {
                    _fusProposalDeleteCommadHandler = new FusProposalDeleteCommadHandler(_mapper, _donorFUSProposalRepository);
                    await _fusProposalDeleteCommadHandler.Handle(new FusProposalDeleteCommad { Id = request.Id }, cancellationToken);
                }
                else
                {
                    _nonFusProposalDeleteCommadHandler = new NonFusProposalDeleteCommadHandler(_mapper, _donorNonFUSProposalRepository, _nonFusProposalBudgetRepository);
                    await _nonFusProposalDeleteCommadHandler.Handle(new NonFusProposalDeleteCommad { Id = request.Id }, cancellationToken);
                }

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
