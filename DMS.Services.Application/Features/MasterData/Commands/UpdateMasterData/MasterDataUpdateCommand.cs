using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class MasterDataUpdateCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
