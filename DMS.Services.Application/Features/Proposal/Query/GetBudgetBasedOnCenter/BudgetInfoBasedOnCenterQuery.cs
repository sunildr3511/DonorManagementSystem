using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class BudgetInfoBasedOnCenterQuery : IRequest<List<BudgetInfoBasedOnCenterVM>>
    {
        public int LocationId { get; set; }
        public int CenterId { get; set; }
        public int PurposeId { get; set; }
    }
}
