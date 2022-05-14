using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
    public class MasterDataListQueryHandler : IRequestHandler<MasterDataListQuery, MasterDataListVM>
    {
        private readonly ISystemConfigurationRepository _systemConfigurationRepository;
        private readonly ILogger<MasterDataListQueryHandler> _logger;
        private readonly ICentreRepository _centerRepository;
        private readonly IMapper _mapper;

        public MasterDataListQueryHandler(ISystemConfigurationRepository systemConfigurationRepository,
                                          ILogger<MasterDataListQueryHandler> logger,
                                          ICentreRepository centreRepository,
                                          IMapper mapper)
        {

            _systemConfigurationRepository = systemConfigurationRepository;
            _logger = logger;
            _centerRepository = centreRepository;
            _mapper = mapper;
        }
        public async Task<MasterDataListVM> Handle(MasterDataListQuery request, CancellationToken cancellationToken)
        {
            MasterDataListVM masterDataListVM;
            try
            {
                masterDataListVM = new MasterDataListVM
                {
                    SystemConfiguration = await _systemConfigurationRepository.GetSystemConfiguration(),
                   
                };

                var allCenters = await _centerRepository.FetchAllCenters();

                masterDataListVM.SystemConfiguration.Centers = _mapper.Map<List<DMS.Services.Domain.MasterEntities.CenterMasterData>>(allCenters);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while fetching master data {ex.Message}");

                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
            return masterDataListVM;
        }
    }
}
