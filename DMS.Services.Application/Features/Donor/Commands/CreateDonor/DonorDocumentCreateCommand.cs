using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class DonorDocumentCreateCommand : IRequest<int>
    {
        public int DonorId { get; set; }

        public IFormFile Document { get; set; }
    }
}
