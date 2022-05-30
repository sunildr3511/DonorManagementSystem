using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Application.Features.Donor;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
    public class AreaManagerDonorListQueryHandler : IRequestHandler<AreaManagerDonorListQuery, List<AreaManagerDonorListVM>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AreaManagerDonorListQueryHandler> _logger;
        private readonly IDonorRepository _repository;
        public AreaManagerDonorListQueryHandler(IMapper mapper, ILogger<AreaManagerDonorListQueryHandler> logger, IDonorRepository repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }
        public async Task<List<AreaManagerDonorListVM>> Handle(AreaManagerDonorListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allDonors = await _repository.FetchAreadManagerDonors(request.LoggedInUserId);

                List<AreaManagerDonorListVM> donorListVMs = _mapper.Map<List<AreaManagerDonorListVM>>(allDonors);

                return donorListVMs;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to fetch all donors for Area Manger because of {ex.Message}");

                throw new Exception(ex.Message);
            }
        }
    }
}
