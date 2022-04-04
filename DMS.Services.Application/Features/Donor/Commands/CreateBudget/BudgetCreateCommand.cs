using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
    public class BudgetCreateCommand : IRequest
    {
        public List<BudgetVM>  ListOfBudget { get; set; }
      
    }
}
