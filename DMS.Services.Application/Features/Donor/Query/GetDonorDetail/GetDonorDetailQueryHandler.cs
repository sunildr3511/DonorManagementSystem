using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IDonorCommentRepository _donorCommentRepository;
        private readonly IKindDonorCommentRepository _kindDonorCommentRepository;

        public GetDonorDetailQueryHandler(IMapper mapper, IAsyncRepository<Domain.Entities.Donor> donorRepository, 
                                    IStakeHolderRepository stakeHolderRepo,IKindDonorRepository kindDonorRepository,
                                    IDonorCommentRepository donorCommentRepository,
                                    IKindDonorCommentRepository kindDonorCommentRepository)
        {
            _mapper = mapper;
            _donorRepository = donorRepository;
            _stakeHolderRepo = stakeHolderRepo;
            _kindDonorRepository = kindDonorRepository;
            _donorCommentRepository = donorCommentRepository;
            _kindDonorCommentRepository = kindDonorCommentRepository;
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

            var donorComments = await _donorCommentRepository.GetCommentsForDonor(donorInfo.Id);

            mappedDonorInfo = _mapper.Map<DonorDetailVM>(donorInfo);

            mappedDonorInfo.StakeHolders = _mapper.Map<List<StakeHolderVM>>(stakeHolders);

            mappedDonorInfo.DonorComments = _mapper.Map<List<DonorCommentVM>>(donorComments);

            mappedDonorInfo.Status = mappedDonorInfo.DonorComments.OrderByDescending(x => x.Id).Where(y => y.DonorId ==request.Id).FirstOrDefault().Status;

            return mappedDonorInfo;
        }

        private async Task<DonorDetailVM> GetKindDonor(GetDonorDetailQuery request, DonorDetailVM mappedDonorInfo)
        {
            var kindDonorInfo = await _kindDonorRepository.GetByIdAsync(request.Id);

            if (kindDonorInfo == null)
            {
                throw new Exceptions.NotFoundException(nameof(Domain.Entities.KindDonor), Convert.ToString(request.Id));
            }
            var kindDonorComments = await _kindDonorCommentRepository.GetCommentsForDonor(kindDonorInfo.Id);

            mappedDonorInfo = _mapper.Map<DonorDetailVM>(kindDonorInfo);

            mappedDonorInfo.DonorComments = _mapper.Map<List<DonorCommentVM>>(kindDonorComments);

            mappedDonorInfo.Status = mappedDonorInfo.DonorComments.OrderByDescending(x => x.Id).Where(y => y.DonorId == request.Id).FirstOrDefault().Status;

            return mappedDonorInfo;
        }
    }
}
