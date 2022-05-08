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
    public class MasterDataDeleteCommandHandler : IRequestHandler<MasterDataDeleteCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<SystemConfiguration> _repository;

        public MasterDataDeleteCommandHandler(IMapper mapper, IAsyncRepository<SystemConfiguration> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(MasterDataDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var masterDataToDelete = await _repository.GetByIdAsync(request.Id);

                if (masterDataToDelete == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.SystemConfiguration), Convert.ToString(request.Id));
                }

                masterDataToDelete.IsActive = false;

                _mapper.Map(request, masterDataToDelete, typeof(MasterDataDeleteCommand), typeof(Domain.Entities.SystemConfiguration));

                await _repository.UpdateAsync(masterDataToDelete);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
