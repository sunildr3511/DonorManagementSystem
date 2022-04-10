using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features.Proposal.Commands.UpdateProposal
{
    public class NonFusProposalUpdateCommandHandler : IRequestHandler<NonFusProposalUpdateCommand>
    {
        private readonly IMapper _mapper;
        private readonly INonFusProposalBudgetRepository _nonFusProposalBudgetRepository;
        private readonly IDonorNonFusProposalRepository _nonFusProposalRepository;

        public NonFusProposalUpdateCommandHandler(IMapper mapper, INonFusProposalBudgetRepository nonFusProposalBudgetRepository, IDonorNonFusProposalRepository nonFusProposalRepository)
        {
            _mapper = mapper;
            _nonFusProposalBudgetRepository = nonFusProposalBudgetRepository;
            _nonFusProposalRepository = nonFusProposalRepository;
        }
        public async Task<Unit> Handle(NonFusProposalUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var nonfusProposalToUpdate = await _nonFusProposalRepository.GetByIdAsync(request.Id);

                if (nonfusProposalToUpdate == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.NonFusProposal), Convert.ToString(request.Id));
                }

                _mapper.Map(request, nonfusProposalToUpdate, typeof(NonFusProposalUpdateCommand), typeof(Domain.Entities.NonFusProposal));

               

                await _nonFusProposalRepository.UpdateAsync(nonfusProposalToUpdate);

                var mappedNonFusProposalBudget = _mapper.Map<List<NonFusProposalBudget>>(request.ListOfBudget);

                foreach (var record in mappedNonFusProposalBudget)
                {
                     await _nonFusProposalBudgetRepository.UpdateNonFusBudgetInfo(request.Id,record.ActivityName,record.CenterAmount,record.BudgetAmount);
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
