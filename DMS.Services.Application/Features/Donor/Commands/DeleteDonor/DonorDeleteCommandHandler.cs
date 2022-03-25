﻿using AutoMapper;
using DMS.Services.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMS.Services.Application.Features
{
   public class DonorDeleteCommandHandler : IRequestHandler<DonorDeleteCommand>
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IStakeHolderRepository _stakeHolderRepository;
        private readonly IMapper _mapper;

        public DonorDeleteCommandHandler(IDonorRepository donorRepository,IStakeHolderRepository stakeHolderRepository,IMapper mapper)
        {
            _donorRepository = donorRepository;
            _stakeHolderRepository = stakeHolderRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DonorDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var donorToDelete = await _donorRepository.GetByIdAsync(request.Id);

                if (donorToDelete == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.Donor), Convert.ToString(request.Id));
                }

               await _stakeHolderRepository.DeleteDonorStakeHolders(request.Id);

               _mapper.Map(request, donorToDelete, typeof(DonorDeleteCommand), typeof(Domain.Entities.Donor));

                await _donorRepository.DeleteAsync(donorToDelete);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}