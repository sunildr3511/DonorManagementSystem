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
    class KindDonorDeleteCommandHandler : IRequestHandler<KindDonorDeleteCommand>
    {
        private readonly IKindDonorRepository _kindDonorRepository;
        private readonly IMapper _mapper;

        public KindDonorDeleteCommandHandler(IKindDonorRepository kindDonorRepository, IMapper mapper)
        {
            _kindDonorRepository = kindDonorRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(KindDonorDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var kindDonorToDelete = await _kindDonorRepository.GetByIdAsync(request.Id);

                if (kindDonorToDelete == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.KindDonor), Convert.ToString(request.Id));
                }

                _mapper.Map(request, kindDonorToDelete, typeof(KindDonorDeleteCommand), typeof(Domain.Entities.KindDonor));

                await _kindDonorRepository.DeleteAsync(kindDonorToDelete);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
