using AutoMapper;
using DMS.Services.Application.Features;
using DMS.Services.Domain.Entities;

namespace DMS.Services.Application.MappingProfiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            //CreateMap<Donor, DonorCreateCommand>().ForMember(x => x.Type, opt =>
            //{
            //    opt.MapFrom(src => src.Type);
            //}).ForMember(x => x.Name, opt =>
            //{
            //    opt.MapFrom(src => src.Name);
            //}).ForMember(x => x.PanCard, opt =>
            //{
            //    opt.MapFrom(src => src.PanCard);
            //}).ForMember(x => x.Category, opt =>
            //{
            //    opt.MapFrom(src => src.Category);
            //}).ForMember(x => x.ReferedBy, opt =>
            //{
            //    opt.MapFrom(src => src.ReferedBy);
            //}).ForMember(x => x.RelationShipManager, opt =>
            //{
            //    opt.MapFrom(src => src.RelationShipManager);
            //}).ForMember(x => x.SourceOfPayment, opt =>
            //{
            //    opt.MapFrom(src => src.SourceOfPayment);
            //}).ForMember(x => x.Purpose, opt =>
            //{
            //    opt.MapFrom(src => src.Purpose);
            //}).ForMember(x => x.Location, opt =>
            //{
            //    opt.MapFrom(src => src.Location);
            //}).ForMember(x => x.Centre, opt =>
            //{
            //    opt.MapFrom(src => src.Centre);
            //}).ForMember(x => x.Comment, opt =>
            //{
            //    opt.MapFrom(src => src.Comment);
            //}).ForMember(x => x.FollowUpDate, opt =>
            //{
            //    opt.MapFrom(src => src.FollowUpDate);
            //}).ForMember(x => x.StakeHolders, opt =>
            //{
            //    opt.MapFrom(src => src.StakeHolders);
            //});
            //CreateMap<StakeHolderDTO, StakeHolderVM>().ReverseMap();

            //  CreateMap<Centre, CentreDataVM>().ReverseMap();
            //CreateMap<Donor, DonorCreateCommand>().ReverseMap();
            CreateMap<CentreDataVM, Centre>().ReverseMap();
        }
    }
}
