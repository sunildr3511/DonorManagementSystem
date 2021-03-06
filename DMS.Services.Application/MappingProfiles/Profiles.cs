using AutoMapper;
using DMS.Services.Application.Common;
using DMS.Services.Application.Features;
using DMS.Services.Application.Features.Donor;
using DMS.Services.Domain.DataModel;
using DMS.Services.Domain.Entities;
using DMS.Services.Domain.MasterEntities;
using DMS.Services.Domain.RoleBasedDonors;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace DMS.Services.Application.MappingProfiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Donor, DonorCreateCommand>().ReverseMap().ForMember(x => x.Type, opt =>
            {
                opt.MapFrom(src => src.Type);
            }).ForMember(x => x.Name, opt =>
            {
                opt.MapFrom(src => src.Name);
            }).ForMember(x => x.PanCard, opt =>
            {
                opt.MapFrom(src => src.PanCard);
            }).ForMember(x => x.Category, opt =>
            {
                opt.MapFrom(src => src.Category);
            }).ForMember(x => x.ReferedBy, opt =>
            {
                opt.MapFrom(src => src.ReferedBy);
            }).ForMember(x => x.RelationShipManager, opt =>
            {
                opt.MapFrom(src => src.RelationShipManager);
            }).ForMember(x => x.SourceOfPayment, opt =>
            {
                opt.MapFrom(src => src.SourceOfPayment);
            }).ForMember(x => x.Purpose, opt =>
            {
                opt.MapFrom(src => src.Purpose);
            }).ForMember(x => x.Location, opt =>
            {
                opt.MapFrom(src => src.Location);
            }).ForMember(x => x.Centre, opt =>
            {
                opt.MapFrom(src => src.Centre);
            }).ForMember(x => x.Comment, opt =>
            {
                opt.MapFrom(src => src.Comment);
            }).ForMember(x => x.FollowUpDate, opt =>
            {
                opt.MapFrom(src => src.FollowUpDate);
            });

            CreateMap<StakeHolder, StakeHolderVM>().ReverseMap();

            CreateMap<Centre, CentreDataVM>().ReverseMap();
           
            CreateMap<CentreDataVM, Centre>().ReverseMap();

            CreateMap<DonorDocument, DonorDocumentCreateCommand>().ReverseMap().ForMember(x => x.Document, opt =>
            {
                opt.MapFrom(src => Utilities.GetDocumentDataInBytes(src.Document));
            });

            CreateMap<DonorDM, DonorListVM>().ReverseMap().ForMember(x=>x.Status, opt =>
            {
                opt.MapFrom(src => src.Status);
            });

            CreateMap<DonorListVM, KindDonorDM>().ReverseMap().ForMember(x => x.Name, opt =>
            {
                opt.MapFrom(src => src.FirstName + "-" + src.LastName);
            }).ForMember(x => x.Status, opt =>
            {
                opt.MapFrom(src => src.Status);
            }); ;

            CreateMap<KindDonor, KindDonorCreateCommand>().ReverseMap();

            CreateMap<DonorDetailVM, Donor>().ReverseMap().ReverseMap().ForMember(x => x.Id, opt =>
            {
                opt.MapFrom(src => src.Id);
            }).ForMember(x => x.DonorId, opt =>
            {
                opt.MapFrom(src => src.DonorId);
            }).ForMember(x => x.Type, opt =>
            {
                opt.MapFrom(src => src.Type);
            }).ForMember(x => x.Name, opt =>
            {
                opt.MapFrom(src => src.Name);
            }).ForMember(x => x.PanCard, opt =>
            {
                opt.MapFrom(src => src.PanCard);
            }).ForMember(x => x.Category, opt =>
            {
                opt.MapFrom(src => src.Category);
            }).ForMember(x => x.ReferedBy, opt =>
            {
                opt.MapFrom(src => src.ReferedBy);
            }).ForMember(x => x.RelationShipManager, opt =>
            {
                opt.MapFrom(src => src.RelationShipManager);
            }).ForMember(x => x.SourceOfPayment, opt =>
            {
                opt.MapFrom(src => src.SourceOfPayment);
            }).ForMember(x => x.Purpose, opt =>
            {
                opt.MapFrom(src => src.Purpose);
            }).ForMember(x => x.Location, opt =>
            {
                opt.MapFrom(src => src.Location);
            }).ForMember(x => x.Centre, opt =>
            {
                opt.MapFrom(src => src.Centre);
            }).ForMember(x => x.Comment, opt =>
            {
                opt.MapFrom(src => src.Comment);
            }).ForMember(x => x.FollowUpDate, opt =>
            {
                opt.MapFrom(src => src.FollowUpDate);
            });

            CreateMap<Donor, DonorDeleteCommand>().ReverseMap();

            CreateMap<StakeHolder, StakeHolderDeleteCommand>().ReverseMap();


            CreateMap<DonorDetailVM, KindDonor>().ReverseMap().ReverseMap().ForMember(x => x.Id, opt =>
            {
                opt.MapFrom(src => src.Id);
            }).ForMember(x => x.DonorId, opt =>
            {
                opt.MapFrom(src => src.DonorId);
            }).ForMember(x => x.FirstName, opt =>
            {
                opt.MapFrom(src => src.FirstName);
            }).ForMember(x => x.LastName, opt =>
            {
                opt.MapFrom(src => src.LastName);
            }).ForMember(x => x.ContactNo, opt =>
            {
                opt.MapFrom(src => src.ContactNo);
            }).ForMember(x => x.Email, opt =>
            {
                opt.MapFrom(src => src.Email);
            }).ForMember(x => x.Address, opt =>
            {
                opt.MapFrom(src => src.Address);
            }).ForMember(x => x.DonationReceived, opt =>
            {
                opt.MapFrom(src => src.DonationReceived);
            }).ForMember(x => x.Quantity, opt =>
            {
                opt.MapFrom(src => src.Quantity);
            }).ForMember(x => x.Description, opt =>
            {
                opt.MapFrom(src => src.Description);
            });

            CreateMap<KindDonor, KindDonorDeleteCommand>().ReverseMap();
            CreateMap<Donor, DonorUpdateCommand>().ReverseMap();
            CreateMap<KindDonor, KindDonorUpdateCommand>().ReverseMap();
            CreateMap<StakeHolder, StakeHolderUpdateCommand>().ReverseMap();
            CreateMap<BudgetInfoBasedOnCenter, BudgetInfoBasedOnCenterVM>().ReverseMap();
            CreateMap<FusProposal, FusProposalCreateCommad>().ReverseMap();
            CreateMap<FusProposal, DonorBasedProposalVM>().ReverseMap();
            CreateMap<FusProposal, FusProposalUpdateCommad>().ReverseMap();
            CreateMap<FusProposal, FusProposalDeleteCommad>().ReverseMap();
            CreateMap<FusProposal, FusProposalDetailVM>().ReverseMap();
            CreateMap<NonFusProposal, NonFusProposalCreateCommand>().ReverseMap().ForMember(x => x.DonorId, opt =>
            {
                opt.MapFrom(src => src.DonorId);
            }).ForMember(x => x.DonorProspectId, opt =>
            {
                opt.MapFrom(src => src.DonorProspectId);
            }).ForMember(x => x.DonorName, opt =>
            {
                opt.MapFrom(src => src.DonorName);
            }).ForMember(x => x.Purpose, opt =>
            {
                opt.MapFrom(src => src.Purpose);
            }).ForMember(x => x.ProposalName, opt =>
            {
                opt.MapFrom(src => src.ProposalName);
            }).ForMember(x => x.LocationId, opt =>
            {
                opt.MapFrom(src => src.LocationId);
            }).ForMember(x => x.CenterId, opt =>
            {
                opt.MapFrom(src => src.CenterId);
            }).ForMember(x => x.NumberOfUnit, opt =>
            {
                opt.MapFrom(src => src.NumberOfUnit);
            }).ForMember(x => x.Unit, opt =>
            {
                opt.MapFrom(src => src.Unit);
            }).ForMember(x => x.PeriodOfDonationFrom, opt =>
            {
                opt.MapFrom(src => src.PeriodOfDonationFrom);
            }).ForMember(x => x.PeriodofDonationTo, opt =>
            {
                opt.MapFrom(src => src.PeriodofDonationTo);
            }).ForMember(x => x.Amount, opt =>
            {
                opt.MapFrom(src => src.Amount);
            }).ForMember(x => x.FrequencyOfNarrativeReport, opt =>
            {
                opt.MapFrom(src => src.FrequencyOfNarrativeReport);
            }).ForMember(x => x.FrequencyOfUtilizationCertificate, opt =>
            {
                opt.MapFrom(src => src.FrequencyOfUtilizationCertificate);
            });
            CreateMap<NonFusProposalBudget, NonFusProposalBudgetVM>().ReverseMap();
            CreateMap<NonFusProposal, DonorBasedProposalVM>().ReverseMap();
            CreateMap<NonFusProposal, NonFusProposalDetailVM>().ReverseMap().ReverseMap().ForMember(x => x.DonorId, opt =>
            {
                opt.MapFrom(src => src.DonorId);
            }).ForMember(x => x.DonorProspectId, opt =>
            {
                opt.MapFrom(src => src.DonorProspectId);
            }).ForMember(x => x.DonorName, opt =>
            {
                opt.MapFrom(src => src.DonorName);
            }).ForMember(x => x.Purpose, opt =>
            {
                opt.MapFrom(src => src.Purpose);
            }).ForMember(x => x.ProposalName, opt =>
            {
                opt.MapFrom(src => src.ProposalName);
            }).ForMember(x => x.LocationId, opt =>
            {
                opt.MapFrom(src => src.LocationId);
            }).ForMember(x => x.CenterId, opt =>
            {
                opt.MapFrom(src => src.CenterId);
            }).ForMember(x => x.NumberOfUnit, opt =>
            {
                opt.MapFrom(src => src.NumberOfUnit);
            }).ForMember(x => x.Unit, opt =>
            {
                opt.MapFrom(src => src.Unit);
            }).ForMember(x => x.PeriodOfDonationFrom, opt =>
            {
                opt.MapFrom(src => src.PeriodOfDonationFrom);
            }).ForMember(x => x.PeriodofDonationTo, opt =>
            {
                opt.MapFrom(src => src.PeriodofDonationTo);
            }).ForMember(x => x.Amount, opt =>
            {
                opt.MapFrom(src => src.Amount);
            }).ForMember(x => x.FrequencyOfNarrativeReport, opt =>
            {
                opt.MapFrom(src => src.FrequencyOfNarrativeReport);
            }).ForMember(x => x.FrequencyOfUtilizationCertificate, opt =>
            {
                opt.MapFrom(src => src.FrequencyOfUtilizationCertificate);
            });

            CreateMap<NonFusProposal, NonFusProposalUpdateCommand>().ReverseMap().ForMember(x => x.DonorId, opt =>
            {
                opt.MapFrom(src => src.DonorId);
            }).ForMember(x => x.DonorProspectId, opt =>
            {
                opt.MapFrom(src => src.DonorProspectId);
            }).ForMember(x => x.DonorName, opt =>
            {
                opt.MapFrom(src => src.DonorName);
            }).ForMember(x => x.Purpose, opt =>
            {
                opt.MapFrom(src => src.Purpose);
            }).ForMember(x => x.ProposalName, opt =>
            {
                opt.MapFrom(src => src.ProposalName);
            }).ForMember(x => x.LocationId, opt =>
            {
                opt.MapFrom(src => src.LocationId);
            }).ForMember(x => x.CenterId, opt =>
            {
                opt.MapFrom(src => src.CenterId);
            }).ForMember(x => x.NumberOfUnit, opt =>
            {
                opt.MapFrom(src => src.NumberOfUnit);
            }).ForMember(x => x.Unit, opt =>
            {
                opt.MapFrom(src => src.Unit);
            }).ForMember(x => x.PeriodOfDonationFrom, opt =>
            {
                opt.MapFrom(src => src.PeriodOfDonationFrom);
            }).ForMember(x => x.PeriodofDonationTo, opt =>
            {
                opt.MapFrom(src => src.PeriodofDonationTo);
            }).ForMember(x => x.Amount, opt =>
            {
                opt.MapFrom(src => src.Amount);
            }).ForMember(x => x.FrequencyOfNarrativeReport, opt =>
            {
                opt.MapFrom(src => src.FrequencyOfNarrativeReport);
            }).ForMember(x => x.FrequencyOfUtilizationCertificate, opt =>
            {
                opt.MapFrom(src => src.FrequencyOfUtilizationCertificate);
            });
            CreateMap<NonFusProposal, NonFusProposalDeleteCommad>().ReverseMap();
            CreateMap<SystemConfiguration, MasterDataCreateCommand>().ReverseMap();
            CreateMap<SystemConfiguration, MasterDataUpdateCommand>().ReverseMap();
            CreateMap<SystemConfiguration, MasterDataDeleteCommand>().ReverseMap();
            CreateMap<StakeHolder, StakeHolderCreateCommand>().ReverseMap();

            CreateMap<UserInfoVM, UserInfo>().ReverseMap();

            CreateMap<CenterMasterData, Centre>().ReverseMap().ForMember(x => x.Id, opt =>
            {
                opt.MapFrom(src => src.Id);
            }).ForMember(x => x.Value, opt =>
            {
                opt.MapFrom(src => src.Name);
            }).ForMember(x => x.IsActive, opt =>
            {
                opt.MapFrom(src => src.IsActive);
            }).ForMember(x => x.LocationId, opt =>
            {
                opt.MapFrom(src => src.LocationId);
            });

            CreateMap<Centre, CenterMasterDataCreateCommand>().ReverseMap();
            CreateMap<Centre, CenterMasterDataUpdateCommand>().ReverseMap();
            CreateMap<Centre, CenterMasterDataDeleteCommand>().ReverseMap();

            CreateMap<UserInfo, UserCreateCommand>().ReverseMap();
            CreateMap<UserInfo, UserUpdateCommand>().ReverseMap();
            CreateMap<UserInfo, UserDeleteCommand>().ReverseMap();
            CreateMap<ReportingManagerDonorList, ReportingManagerDonorListVM>().ReverseMap();
            CreateMap<DonorCommentInfoDM, DonorCommentVM>().ReverseMap();
            CreateMap<KindDonorCommentInfoDM, DonorCommentVM>().ReverseMap();
            CreateMap<KindDonorCommentInfo, DonorCommentVM>().ReverseMap();
            CreateMap<DonorCommentInfo, DonorCommentVM>().ReverseMap();
        }
    }
}
