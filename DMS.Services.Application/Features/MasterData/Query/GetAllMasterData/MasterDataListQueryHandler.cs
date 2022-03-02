using DMS.Services.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;

namespace DMS.Services.Application.Features.MasterData.Query.GetAllMasterData
{
    public class MasterDataListQueryHandler : IRequestHandler<MasterDataListQuery, MasterDataListVM>
    {
        private readonly ISystemConfigurationRepository _systemConfigurationRepository;
        private readonly ILogger<MasterDataListQueryHandler> _logger;

        public MasterDataListQueryHandler(ISystemConfigurationRepository systemConfigurationRepository,
                                       ILogger<MasterDataListQueryHandler> logger)
        {
      
            _systemConfigurationRepository = systemConfigurationRepository;
            _logger = logger;
        }
        public async Task<MasterDataListVM> Handle(MasterDataListQuery request, CancellationToken cancellationToken)
        {
            MasterDataListVM masterDataListVM;

            try
            {
                masterDataListVM = new MasterDataListVM
                {
                    SystemConfiguration = await _systemConfigurationRepository.GetSystemConfiguration()
                };
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
