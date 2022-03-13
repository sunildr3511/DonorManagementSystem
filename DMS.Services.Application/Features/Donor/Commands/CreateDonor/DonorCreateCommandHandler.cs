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
    public class DonorCreateCommandHandler : IRequestHandler<DonorCreateCommand, DonorVM>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Donor> _repository;
        private readonly IAsyncRepository<StakeHolder> _stakeHolderRepo;
        public DonorCreateCommandHandler(IMapper mapper, IAsyncRepository<Donor> repository, IAsyncRepository<StakeHolder> stakeHolderRepo)
        {
            _mapper = mapper;
            _repository = repository;
            _stakeHolderRepo = stakeHolderRepo;
        }

        public async Task<DonorVM> Handle(DonorCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var @donorEntity = await _repository.AddAsync(new Donor
                {
                    DonorId = "DNR_" + request.Location + "_" + request.Centre,
                    Type = request.Type,
                    Name = request.Name,
                    PanCard = request.PanCard,
                    Category = request.Category,
                    ReferedBy = request.ReferedBy,
                    RelationShipManager = request.RelationShipManager,
                    SourceOfPayment = request.SourceOfPayment,
                    Purpose = request.Purpose,
                    Location = request.Location,
                    Centre = request.Centre,
                    Comment = request.Comment,
                    FollowUpDate = request.FollowUpDate
                });

                foreach (var stakHolder in request.StakeHolders)
                {
                    var @stakeHolderInfo = await _stakeHolderRepo.AddAsync(new StakeHolder
                    {
                        DonorId = donorEntity.Id,
                        Salutation = stakHolder.Salutation,
                        Name = stakHolder.Name,
                        Designation = stakHolder.Designation,
                        Company = stakHolder.Company,
                        EmailId = stakHolder.EmailId,
                        MobileNo = stakHolder.MobileNo,
                        Address = stakHolder.Address,
                        DecisionMaker = stakHolder.DecisionMaker,
                        DOB = stakHolder.DOB
                    });
                }

                return new DonorVM { Id = @donorEntity.Id, DonorId = donorEntity.DonorId };
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
