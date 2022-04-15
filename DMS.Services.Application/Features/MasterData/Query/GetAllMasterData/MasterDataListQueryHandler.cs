using DMS.Services.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
    public class MasterDataListQueryHandler : IRequestHandler<MasterDataListQuery, MasterDataListVM>
    {
        private readonly ISystemConfigurationRepository _systemConfigurationRepository;
        private readonly ILogger<MasterDataListQueryHandler> _logger;
        private readonly ILocationRepository _locationRepository;

        public MasterDataListQueryHandler(ISystemConfigurationRepository systemConfigurationRepository,
                                          ILogger<MasterDataListQueryHandler> logger,
                                          ILocationRepository locationRepository)
        {

            _systemConfigurationRepository = systemConfigurationRepository;
            _logger = logger;
            _locationRepository = locationRepository;
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
              // masterDataListVM.SystemConfiguration.Locations= await _locationRepository.GetLocations();
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
