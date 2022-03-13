using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
    public class DonorCreateCommandHandler : IRequestHandler<DonorCreateCommand, DonorVM>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Donor> _repository;
        private readonly IAsyncRepository<StakeHolder> _stakeHolderRepo;
        public DonorCreateCommandHandler(IMapper mapper, IAsyncRepository<Donor> repository, IAsyncRepository<StakeHolder> stakeHolderRepo)
        {
            _mapper = mapper;
            _repository = repository;
            _stakeHolderRepo = stakeHolderRepo;
        }

        public async Task<DonorVM> Handle(DonorCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedDonor= _mapper.Map<Donor>(request);

                mappedDonor.DonorId = "DNR_" + request.Location + "_" + request.Centre;

                var @donorEntity = await _repository.AddAsync(mappedDonor);

                var mappedStakeHolders = _mapper.Map<List<StakeHolder>>(request.StakeHolders);

                foreach (var stakHolder in mappedStakeHolders)
                {
                    stakHolder.DonorId = donorEntity.Id;

                    await _stakeHolderRepo.AddAsync(stakHolder);
                }

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
