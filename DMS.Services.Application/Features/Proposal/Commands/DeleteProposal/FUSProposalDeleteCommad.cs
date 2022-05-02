﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class ProposalDeleteCommad : IRequest
    {
        public int Id { get; set; }

        public int ProposalTypeId { get; set; }
    }
}
