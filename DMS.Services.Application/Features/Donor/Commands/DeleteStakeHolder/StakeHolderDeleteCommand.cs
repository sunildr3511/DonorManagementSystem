﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class StakeHolderDeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}