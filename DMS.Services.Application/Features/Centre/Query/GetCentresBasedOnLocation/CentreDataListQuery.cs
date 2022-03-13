using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class CentreDataListQuery : IRequest<List<CentreDataVM>>
    {
        public int Id { get; set; }
    }
}
