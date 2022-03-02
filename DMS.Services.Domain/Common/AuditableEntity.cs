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

        public string Status { get; set; }

        public string Comment { get; set; }

        public string AssignedTo { get; set; }
    }
}
