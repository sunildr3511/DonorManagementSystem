using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class CenterMasterDataCreateCommand : IRequest
    {
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
