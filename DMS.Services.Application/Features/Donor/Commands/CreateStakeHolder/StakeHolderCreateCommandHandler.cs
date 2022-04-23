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
    public class StakeHolderCreateCommandHandler : IRequestHandler<StakeHolderCreateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IStakeHolderRepository _stakeHolderRepo;
        public StakeHolderCreateCommandHandler(IMapper mapper, IStakeHolderRepository stakeHolderRepo)
        {
            _mapper = mapper;
            _stakeHolderRepo = stakeHolderRepo;
        }
        public async Task<Unit> Handle(StakeHolderCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new StakeHolderCreateCommandValidator();

                var validationResult = await validator.ValidateAsync(request);

                if (validationResult.Errors.Count > 0)
                {
                    throw new Exceptions.ValidationException(validationResult);
                }

                var mappedData = _mapper.Map<DMS.Services.Domain.Entities.StakeHolder>(request);

                await _stakeHolderRepo.AddAsync(mappedData);

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
