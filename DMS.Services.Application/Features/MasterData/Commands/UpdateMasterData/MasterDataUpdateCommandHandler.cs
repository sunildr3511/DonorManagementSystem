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
    public class MasterDataUpdateCommandHandler : IRequestHandler<MasterDataUpdateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<SystemConfiguration> _repository;

        public MasterDataUpdateCommandHandler(IMapper mapper, IAsyncRepository<SystemConfiguration> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(MasterDataUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var masterDataToUpdate = await _repository.GetByIdAsync(request.Id);

                if (masterDataToUpdate == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.SystemConfiguration), Convert.ToString(request.Id));
                }

                _mapper.Map(request, masterDataToUpdate, typeof(MasterDataUpdateCommand), typeof(Domain.Entities.SystemConfiguration));

                await _repository.UpdateAsync(masterDataToUpdate);

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
