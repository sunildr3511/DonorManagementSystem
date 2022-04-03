using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Domain.Entities
{
   public class CenterBasedBudgetInfo
    {
        public int Id { get; set; }
        public int LocationId { get; set; }

        public int CenterId { get; set; }

        public string PurposeName { get; set; }

        public string BudgetActivityName { get; set; }

        public double BudgetAmount { get; set; }
    }
}
