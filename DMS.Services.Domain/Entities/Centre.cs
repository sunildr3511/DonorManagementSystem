using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Domain.Entities
{
   public class Centre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
    }
}
