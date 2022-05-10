using DMS.Services.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Domain.Entities
{
   public class RoleInfo : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
