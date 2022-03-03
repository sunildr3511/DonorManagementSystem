using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Domain.Entities
{
   public class Donor
    {
        public int Id { get; set; }
        public string DonorId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string PanCard { get; set; }
        public string Category { get; set; }
    }
}
