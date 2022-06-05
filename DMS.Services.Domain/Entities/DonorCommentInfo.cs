using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Domain.Entities
{
   public class DonorCommentInfo
    {
        public int Id { get; set; }

        public int DonorId { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public int CommentBy { get; set; }
    }
}
