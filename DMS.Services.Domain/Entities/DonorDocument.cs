using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Domain.Entities
{
   public class DonorDocument
    {
        public int Id { get; set; }

        public int DonorId { get; set; }

        public byte[] Document { get; set; }
    }
}
