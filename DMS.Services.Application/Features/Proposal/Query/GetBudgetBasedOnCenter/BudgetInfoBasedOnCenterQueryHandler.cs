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
    public class BudgetInfoBasedOnCenterQueryHandler : IRequestHandler<BudgetInfoBasedOnCenterQuery, List<BudgetInfoBasedOnCenterVM>>
    {
        private readonly IMapper _mapper;
        private readonly IBudgetInfoBasedOnCenterRepository _budgetInfoBasedOnCenterRepository;
        public BudgetInfoBasedOnCenterQueryHandler(IMapper mapper, IBudgetInfoBasedOnCenterRepository budgetInfoBasedOnCenterRepository)
        {
            _mapper = mapper;
            _budgetInfoBasedOnCenterRepository = budgetInfoBasedOnCenterRepository;

        }
        public async Task<List<BudgetInfoBasedOnCenterVM>> Handle(BudgetInfoBasedOnCenterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _budgetInfoBasedOnCenterRepository.FetchBudgetInfoBasedOnCenter(request.LocationId, request.CenterId, request.PurposeId);

                var mappedResult = _mapper.Map<List<BudgetInfoBasedOnCenterVM>>(result);

                return mappedResult;
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
