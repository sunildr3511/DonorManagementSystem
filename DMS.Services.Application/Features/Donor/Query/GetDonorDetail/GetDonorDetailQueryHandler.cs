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
        private readonly IKindDonorRepository _kindDonorRepository;
        private readonly IStakeHolderRepository _stakeHolderRepo;

        public GetDonorDetailQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Donor> donorRepository, IStakeHolderRepository stakeHolderRepo,IKindDonorRepository kindDonorRepository)
        {
            _mapper = mapper;
            _donorRepository = donorRepository;
            _stakeHolderRepo = stakeHolderRepo;
            _kindDonorRepository = kindDonorRepository;
        }
        public async Task<DonorDetailVM> Handle(GetDonorDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                DonorDetailVM mappedDonorInfo = new DonorDetailVM();
               
                if (request.DonorTypeId == 0)
                {
                    mappedDonorInfo = await GetKindDonor(request, mappedDonorInfo);
                }
                else if( request.DonorTypeId ==1)
                {
                    mappedDonorInfo = await GetDonorProfileInfo(request, mappedDonorInfo);
                }

                return mappedDonorInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        private async Task<DonorDetailVM> GetDonorProfileInfo(GetDonorDetailQuery request, DonorDetailVM mappedDonorInfo)
        {
            var donorInfo = await _donorRepository.GetByIdAsync(request.Id);

            if (donorInfo == null)
            {
                throw new Exceptions.NotFoundException(nameof(Domain.Entities.Donor), Convert.ToString(request.Id));
            }

            var stakeHolders = await _stakeHolderRepo.GetStakeHoldersForDonor(donorInfo.Id);

            mappedDonorInfo = _mapper.Map<DonorDetailVM>(donorInfo);

            mappedDonorInfo.StakeHolders = _mapper.Map<List<StakeHolderVM>>(stakeHolders);

            return mappedDonorInfo;
        }

        private async Task<DonorDetailVM> GetKindDonor(GetDonorDetailQuery request, DonorDetailVM mappedDonorInfo)
        {
            var kindDonorInfo = await _kindDonorRepository.GetByIdAsync(request.Id);

            if (kindDonorInfo == null)
            {
                throw new Exceptions.NotFoundException(nameof(Domain.Entities.KindDonor), Convert.ToString(request.Id));
            }

            mappedDonorInfo = _mapper.Map<DonorDetailVM>(kindDonorInfo);

            return mappedDonorInfo;
        }
    }
}
