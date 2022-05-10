using DMS.Services.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Domain.Entities
{
   public class UserInfo : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public int LocationId { get; set; }

        public int CenterId { get; set; }
    }
}
