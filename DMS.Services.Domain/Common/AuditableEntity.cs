using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Domain.Common
{
    public class AuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public bool IsActive { get; set; }
      
    }
}
