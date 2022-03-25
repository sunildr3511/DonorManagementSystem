using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
    public class DonorListQueryHandler : IRequestHandler<DonorListQuery, List<DonorListVM>>
    {
        private readonly IMapper _mapper;
        private readonly IDonorRepository _repository;
        private readonly IKindDonorRepository _kindDonorRepository;
        private readonly ILogger<DonorListQueryHandler> _logger;
        public DonorListQueryHandler(IMapper mapper, IDonorRepository repository,IKindDonorRepository kindDonorRepository, ILogger<DonorListQueryHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _kindDonorRepository = kindDonorRepository;
            _logger = logger;
        }
        public async Task<List<DonorListVM>> Handle(DonorListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allDonors = await _repository.GetAllDonors();

                List<DonorListVM> donorListVMs=  _mapper.Map<List<DonorListVM>>(allDonors);

                var allKindDonors = await _kindDonorRepository.GetAllKindDonors();

                donorListVMs.AddRange(_mapper.Map<List<DonorListVM>>(allKindDonors));

                return donorListVMs;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to fetch all donors because of {ex.Message}");

                throw new Exception(ex.Message);
            }
        }
    }
}
