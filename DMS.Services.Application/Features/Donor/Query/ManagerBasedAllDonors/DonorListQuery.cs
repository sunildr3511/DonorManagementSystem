using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class DonorListQuery : IRequest<List<DonorListVM>>
    {
        public int LoggedInUserId { get; set; }
    }
}
