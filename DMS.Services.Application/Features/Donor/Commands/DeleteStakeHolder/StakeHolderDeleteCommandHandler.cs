using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features.Donor.Commands.DeleteStakeHolder
{
   public class StakeHolderDeleteCommandHandler : IRequestHandler<StakeHolderDeleteCommand>
    {
        private readonly IStakeHolderRepository _stakeHolderRepository;
        private readonly IMapper _mapper;

        public StakeHolderDeleteCommandHandler(IStakeHolderRepository stakeHolderRepository, IMapper mapper)
        {
            _stakeHolderRepository = stakeHolderRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(StakeHolderDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var stakeHolderToDelete = await _stakeHolderRepository.GetByIdAsync(request.Id);

                if (stakeHolderToDelete == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.StakeHolder), Convert.ToString(request.Id));
                }

                _mapper.Map(request, stakeHolderToDelete, typeof(StakeHolderDeleteCommand), typeof(Domain.Entities.StakeHolder));

                await _stakeHolderRepository.DeleteAsync(stakeHolderToDelete);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
