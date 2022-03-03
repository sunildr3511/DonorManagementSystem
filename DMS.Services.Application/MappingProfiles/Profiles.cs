using AutoMapper;
using DMS.Services.Application.Features.Donor.Commands.CreateDonor;
using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.MappingProfiles
{
   public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Donor, DonorCreateCommand>().ReverseMap();
        }
    }
}
