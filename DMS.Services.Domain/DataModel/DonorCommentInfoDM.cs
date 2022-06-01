using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Domain.DataModel
{
   public class DonorCommentInfoDM
    {
        public int Id { get; set; }

        public int DonorId { get; set; }

        public bool IsApproved { get; set; }

        public string Comments { get; set; }

        public int CommentBy { get; set; }

        public string CommentByName { get; set; }
    }
}
