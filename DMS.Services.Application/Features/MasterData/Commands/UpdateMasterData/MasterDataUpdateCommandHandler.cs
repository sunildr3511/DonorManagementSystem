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
    public class CenterMasterDataUpdateCommandHandler : IRequestHandler<CenterMasterDataUpdateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Centre> _repository;

        public CenterMasterDataUpdateCommandHandler(IMapper mapper, IAsyncRepository<Centre> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(CenterMasterDataUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var masterDataToUpdate = await _repository.GetByIdAsync(request.Id);

                if (masterDataToUpdate == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.Centre), Convert.ToString(request.Id));
                }

                _mapper.Map(request, masterDataToUpdate, typeof(CenterMasterDataUpdateCommand), typeof(Domain.Entities.Centre));

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
