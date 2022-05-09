using DMS.Services.Domain.Common;
using System;

namespace DMS.Services.Domain.Entities
{
    public class SystemConfiguration : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
      
    }
}
