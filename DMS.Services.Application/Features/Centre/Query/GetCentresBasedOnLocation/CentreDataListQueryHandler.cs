using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
    public class CentreDataListQueryHandler : IRequestHandler<CentreDataListQuery, List<CentreDataVM>>
    {
        private readonly IMapper _mapper;
        private readonly ICentreRepository _centreRepository;

        public CentreDataListQueryHandler(IMapper mapper, ICentreRepository centreRepository)
        {
            _mapper = mapper;
            _centreRepository = centreRepository;
        }

        public async Task<List<CentreDataVM>> Handle(CentreDataListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var centres = await _centreRepository.GetCentresBasedOnLocation(request.Id);

                return _mapper.Map<List<CentreDataVM>>(centres);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
