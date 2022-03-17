using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
    public class KindDonorCreateCommadHandler : IRequestHandler<KindDonorCreateCommand, DonorVM>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.KindDonor> _repository;
        private readonly IKindDonorRepository _kindDonorRepository;

        public KindDonorCreateCommadHandler(IMapper mapper, IAsyncRepository<Domain.Entities.KindDonor> repository, IKindDonorRepository kindDonorRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _kindDonorRepository = kindDonorRepository;
        }
        public async Task<DonorVM> Handle(KindDonorCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedDonor = _mapper.Map<DMS.Services.Domain.Entities.KindDonor>(request);

                var maxDonorId = await _kindDonorRepository.GetMaxId();

                mappedDonor.DonorId = "DNR_Location_" + maxDonorId;

                var @donorEntity = await _repository.AddAsync(mappedDonor);

                return new DonorVM { Id = @donorEntity.Id, DonorId = donorEntity.DonorId };
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
