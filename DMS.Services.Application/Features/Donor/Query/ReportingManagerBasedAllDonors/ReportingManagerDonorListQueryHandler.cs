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
    public class ReportingManagerDonorListQueryHandler : IRequestHandler<ReportingManagerDonorListQuery, List<ReportingManagerDonorListVM>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ReportingManagerDonorListQueryHandler> _logger;
        private readonly IDonorRepository _repository;
        public ReportingManagerDonorListQueryHandler(IMapper mapper, ILogger<ReportingManagerDonorListQueryHandler> logger, IDonorRepository repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }
        public async Task<List<ReportingManagerDonorListVM>> Handle(ReportingManagerDonorListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allDonors = await _repository.FetchReportingManagerDonors(request.LoggedInUserId);

                List<ReportingManagerDonorListVM> donorListVMs = _mapper.Map<List<ReportingManagerDonorListVM>>(allDonors);

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
