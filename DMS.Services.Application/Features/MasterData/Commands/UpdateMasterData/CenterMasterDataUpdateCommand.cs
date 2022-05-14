using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class CenterMasterDataUpdateCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int LocationId { get; set; }

        public bool IsActive { get; set; }

        public int UpdatedBy { get; set; }

    }
}
