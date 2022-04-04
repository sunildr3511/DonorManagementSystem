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
    public class BudgetCreateCommandHandler : IRequestHandler<BudgetCreateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.DonorBasedBudgetInfo> _repository;

        public BudgetCreateCommandHandler(IAsyncRepository<Domain.Entities.DonorBasedBudgetInfo> repository,
                                        IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(BudgetCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedDonorBasedBudgets = _mapper.Map<List<DonorBasedBudgetInfo>>(request.ListOfBudget);

                foreach (var donorBudget in mappedDonorBasedBudgets)
                {
                    await _repository.AddAsync(donorBudget);
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
