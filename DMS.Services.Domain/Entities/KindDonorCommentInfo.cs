using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Domain.Entities
{
   public class KindDonorCommentInfo
    {
        public int Id { get; set; }

        public int DonorId { get; set; }

        public bool IsApproved { get; set; }

        public string Comments { get; set; }

        public int CommentBy { get; set; }
    }
}
