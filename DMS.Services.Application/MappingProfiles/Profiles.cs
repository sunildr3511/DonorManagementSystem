using AutoMapper;
using DMS.Services.Application.Common;
using DMS.Services.Application.Features;
using DMS.Services.Domain.Entities;
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

            CreateMap<Donor, DonorListVM>().ReverseMap();

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
        }

        
    }
}
