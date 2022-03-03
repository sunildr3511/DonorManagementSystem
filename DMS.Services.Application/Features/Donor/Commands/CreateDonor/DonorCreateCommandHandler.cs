using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features.Donor.Commands.CreateDonor
{
   public class DonorCreateCommandHandler : IRequestHandler<DonorCreateCommand, DonorVM>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Donor> _repository;
        public DonorCreateCommandHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Donor> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<DonorVM> Handle(DonorCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var donor = _mapper.Map<Domain.Entities.Donor>(request);

                donor.DonorId = "DONOR_" + Guid.NewGuid().ToString();

                var @donorEntity = await _repository.AddAsync(donor);

                return new DonorVM { Id = @donorEntity.Id, DonorId = donorEntity.DonorId};
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
