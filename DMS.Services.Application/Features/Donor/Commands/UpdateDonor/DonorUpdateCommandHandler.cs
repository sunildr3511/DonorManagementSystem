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
    public class DonorUpdateCommandHandler : IRequestHandler<DonorUpdateCommand>
    {
        private readonly IMapper _mapper;
        private readonly IDonorRepository _donorRepository;

        public DonorUpdateCommandHandler(IMapper mapper, IDonorRepository donorRepository)
        {
            _mapper = mapper;
            _donorRepository = donorRepository;
        }
        public async Task<Unit> Handle(DonorUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var donorToUpdate = await _donorRepository.GetByIdAsync(request.Id);

                if (donorToUpdate == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.Donor), Convert.ToString(request.Id));
                }

                _mapper.Map(request, donorToUpdate, typeof(DonorUpdateCommand), typeof(Domain.Entities.Donor));

                await _donorRepository.UpdateAsync(donorToUpdate);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                if (ex is Exceptions.ValidationException)
                    throw new Exception(string.Join(",", (ex as Exceptions.ValidationException).ValidationErrors));
                else
                    throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
