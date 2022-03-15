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
        private readonly ILogger<DonorListQueryHandler> _logger;
        public DonorListQueryHandler(IMapper mapper, IDonorRepository repository, ILogger<DonorListQueryHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }
        public async Task<List<DonorListVM>> Handle(DonorListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allDonors = await _repository.GetAllDonors();

                return _mapper.Map<List<DonorListVM>>(allDonors);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to fetch all donors because of {ex.Message}");

                throw new Exception(ex.Message);
            }
        }
    }
}
