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
    public class GetDonorDetailQueryHandler : IRequestHandler<GetDonorDetailQuery, DonorDetailVM>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Donor> _donorRepository;
        private readonly IStakeHolderRepository _stakeHolderRepo;

        public GetDonorDetailQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Donor> donorRepository, IStakeHolderRepository stakeHolderRepo)
        {
            _mapper = mapper;
            _donorRepository = donorRepository;
            _stakeHolderRepo = stakeHolderRepo;
        }
        public async Task<DonorDetailVM> Handle(GetDonorDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var donorInfo = await _donorRepository.GetByIdAsync(request.Id);

                var stakeHolders = await _stakeHolderRepo.GetStakeHoldersForDonor(donorInfo.Id);

                var mappedDonorInfo= _mapper.Map<DonorDetailVM>(donorInfo);

                mappedDonorInfo.StakeHolders = _mapper.Map<List<StakeHolderVM>>(stakeHolders); ;

                return mappedDonorInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
