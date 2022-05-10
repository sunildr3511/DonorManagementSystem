using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features.MasterData.Commands.CreateMasterData
{
    public class MasterDataCreateCommandHandler : IRequestHandler<MasterDataCreateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<SystemConfiguration> _repository;

        public MasterDataCreateCommandHandler(IMapper mapper, IAsyncRepository<SystemConfiguration> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(MasterDataCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.IsActive = true;

                var mappedRequest = _mapper.Map<SystemConfiguration>(request);

                await _repository.AddAsync(mappedRequest);

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
