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
   public class NonFusProposalDeleteCommadHandler :IRequestHandler<NonFusProposalDeleteCommad>
    {
        private readonly IMapper _mapper;
        private readonly IDonorNonFusProposalRepository _donorNonFUSProposalRepository;
        private readonly INonFusProposalBudgetRepository _nonFusProposalBudgetRepository;

        public NonFusProposalDeleteCommadHandler(IMapper mapper, IDonorNonFusProposalRepository donorNonFUSProposalRepository,INonFusProposalBudgetRepository nonFusProposalBudgetRepository)
        {
            _mapper = mapper;
            _donorNonFUSProposalRepository = donorNonFUSProposalRepository;
            _nonFusProposalBudgetRepository = nonFusProposalBudgetRepository;
        }

        public async Task<Unit> Handle(NonFusProposalDeleteCommad request, CancellationToken cancellationToken)
        {
            try
            {
                var NonfusProposalToDelete = await _donorNonFUSProposalRepository.GetByIdAsync(request.Id);

                if (NonfusProposalToDelete == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.NonFusProposal), Convert.ToString(request.Id));
                }

                await _nonFusProposalBudgetRepository.DeleteNonFusProposalBudgets(request.Id);

                _mapper.Map(request, NonfusProposalToDelete, typeof(NonFusProposalDeleteCommad), typeof(Domain.Entities.NonFusProposal));

                await _donorNonFUSProposalRepository.DeleteAsync(NonfusProposalToDelete);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
