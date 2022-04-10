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
    public class FUSProposalUpdateCommadHandler : IRequestHandler<FUSProposalUpdateCommad>
    {
        private readonly IMapper _mapper;
        private readonly IDonorFUSProposalRepository _donorFUSProposalRepository;
        public FUSProposalUpdateCommadHandler(IMapper mapper, IDonorFUSProposalRepository donorFUSProposalRepository)
        {
            _mapper = mapper;
            _donorFUSProposalRepository = donorFUSProposalRepository;
        }
        public async Task<Unit> Handle(FUSProposalUpdateCommad request, CancellationToken cancellationToken)
        {
            try
            {
                var fusProposalToUpdate = await _donorFUSProposalRepository.GetByIdAsync(request.Id);

                if (fusProposalToUpdate == null)
                {
                    throw new Exceptions.NotFoundException(nameof(Domain.Entities.FamilyUnitSponsorProposal), Convert.ToString(request.Id));
                }

                _mapper.Map(request, fusProposalToUpdate, typeof(FUSProposalUpdateCommad), typeof(Domain.Entities.FamilyUnitSponsorProposal));

                await _donorFUSProposalRepository.UpdateAsync(fusProposalToUpdate);

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