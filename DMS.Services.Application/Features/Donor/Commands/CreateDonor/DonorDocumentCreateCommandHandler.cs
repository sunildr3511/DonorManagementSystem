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
    public class DonorDocumentCreateCommandHandler : IRequestHandler<DonorDocumentCreateCommand,int>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<DonorDocument> _repository;
       
        public DonorDocumentCreateCommandHandler(IMapper mapper, IAsyncRepository<DonorDocument> repository)
        {
            _mapper = mapper;
            _repository = repository;
           
        }

        public async Task<int> Handle(DonorDocumentCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedDonorDocument = _mapper.Map<DMS.Services.Domain.Entities.DonorDocument>(request);
               
                var @donorDocument= await _repository.AddAsync(mappedDonorDocument);

                return @donorDocument.DonorId;
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
