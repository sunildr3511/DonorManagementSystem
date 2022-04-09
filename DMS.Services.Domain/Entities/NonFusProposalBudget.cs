using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Domain.Entities
{
   public class NonFusProposalBudget
    {
        public int Id { get; set; }

        public int DonorId { get; set; }

        public int ProposalId { get; set; }

        public string ActivityName { get; set; }

        public double CenterAmount { get; set; }

        public double BudgetAmount { get; set; }
    }
}
