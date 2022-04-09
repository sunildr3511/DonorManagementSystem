using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
    public class NonFusProposalCreateCommandHandler : IRequestHandler<NonFusProposalCreateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<NonFusProposalBudget> _nonFusProposalBudgetRepository;
        private readonly IDonorNonFusProposalRepository _nonFusProposalRepository;
        public NonFusProposalCreateCommandHandler(IMapper mapper, IAsyncRepository<NonFusProposalBudget> nonFusProposalBudgetRepository, IDonorNonFusProposalRepository nonFusProposalRepository)
        {
            _mapper = mapper;
            _nonFusProposalBudgetRepository = nonFusProposalBudgetRepository;
            _nonFusProposalRepository = nonFusProposalRepository;
        }
        public async Task<Unit> Handle(NonFusProposalCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedNonFusProposal=   _mapper.Map<NonFusProposal>(request);

                var @savedRecord=  await _nonFusProposalRepository.AddAsync(mappedNonFusProposal);

                var mappedNonFusProposalBudget = _mapper.Map<List<NonFusProposalBudget>>(request.ListOfBudget);

                foreach (var record in mappedNonFusProposalBudget)
                {
                    record.DonorId = @savedRecord.DonorId;
                    record.ProposalId = @savedRecord.Id;
                    await _nonFusProposalBudgetRepository.AddAsync(record);
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
