using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features.Donor.Commands.UpdateStakeHolder
{
    public class StakeHolderUpdateCommandHandler : IRequestHandler<StakeHolderUpdateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IStakeHolderRepository _stakeHolderRepository;

        public StakeHolderUpdateCommandHandler(IMapper mapper, IStakeHolderRepository stakeHolderRepository)
        {
            _mapper = mapper;
            _stakeHolderRepository = stakeHolderRepository;
        }
        public async Task<Unit> Handle(StakeHolderUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var stakeHolderToUpdate = await _stakeHolderRepository.GetByIdAsync(request.Id);

                if (stakeHolderToUpdate == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.StakeHolder), Convert.ToString(request.Id));
                }

                _mapper.Map(request, stakeHolderToUpdate, typeof(StakeHolderUpdateCommand), typeof(Domain.Entities.StakeHolder));

                await _stakeHolderRepository.UpdateAsync(stakeHolderToUpdate);

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
