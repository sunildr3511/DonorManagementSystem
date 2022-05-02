using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Application.Features;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
    public class ProposalUpdateCommandHandler : IRequestHandler<ProposalUpdateCommand>
    {

        private readonly IMapper _mapper;

        private readonly IDonorFusProposalRepository _donorFUSProposalRepository;
        private FusProposalUpdateCommadHandler _fusProposalUpdateCommandHandler;

        private readonly INonFusProposalBudgetRepository _nonFusProposalBudgetRepository;
        private readonly IDonorNonFusProposalRepository _nonFusProposalRepository;
        private  NonFusProposalUpdateCommandHandler _nonFusProposalUpdateCommandHandler;
       

        public ProposalUpdateCommandHandler(IMapper mapper, 
                                            INonFusProposalBudgetRepository nonFusProposalBudgetRepository, 
                                            IDonorNonFusProposalRepository nonFusProposalRepository,
                                            IDonorFusProposalRepository donorFUSProposalRepository)
        {
            _mapper = mapper;
            _nonFusProposalBudgetRepository = nonFusProposalBudgetRepository;
            _nonFusProposalRepository = nonFusProposalRepository;
            _donorFUSProposalRepository = donorFUSProposalRepository;
        }
        public async Task<Unit> Handle(ProposalUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.NonFusProposalUpdateCommand != null && request.NonFusProposalUpdateCommand.Id != 0)
                {
                    _nonFusProposalUpdateCommandHandler = new NonFusProposalUpdateCommandHandler(_mapper, _nonFusProposalBudgetRepository, _nonFusProposalRepository);
                    await _nonFusProposalUpdateCommandHandler.Handle(request.NonFusProposalUpdateCommand, cancellationToken);
                }

                if (request.FusProposalUpdateCommad != null && request.FusProposalUpdateCommad.Id!=0)
                {
                    _fusProposalUpdateCommandHandler = new FusProposalUpdateCommadHandler(_mapper, _donorFUSProposalRepository);
                    await _fusProposalUpdateCommandHandler.Handle(request.FusProposalUpdateCommad, cancellationToken);
                }

                return Unit.Value;
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
