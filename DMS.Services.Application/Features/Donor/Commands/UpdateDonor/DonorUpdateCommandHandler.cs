using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
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
        private readonly IDonorCommentRepository _donorCommentRepository;

        public DonorUpdateCommandHandler(IMapper mapper, IDonorRepository donorRepository,IDonorCommentRepository donorCommentRepository)
        {
            _mapper = mapper;
            _donorRepository = donorRepository;
            _donorCommentRepository = donorCommentRepository;
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

                var mappedDonorCommet = _mapper.Map<DonorCommentInfo>(request.DonorComment);

                await _donorCommentRepository.AddAsync(mappedDonorCommet);

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
