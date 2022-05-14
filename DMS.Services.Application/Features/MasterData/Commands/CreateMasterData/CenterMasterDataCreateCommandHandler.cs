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
    public class CenterMasterDataCreateCommandHandler : IRequestHandler<CenterMasterDataCreateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Centre> _repository;

        public CenterMasterDataCreateCommandHandler(IMapper mapper, IAsyncRepository<Centre> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(CenterMasterDataCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var mappedRequest = _mapper.Map<Centre>(request);

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
