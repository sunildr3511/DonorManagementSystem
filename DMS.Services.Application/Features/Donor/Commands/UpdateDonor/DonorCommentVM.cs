using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class DonorCommentVM
    {
        public int DonorId { get; set; }

      //  public bool IsApproved { get; set; }

        public string Comments { get; set; }

        public int CommentBy { get; set; }

        public string CommentByName { get; set; }

        public string Status { get; set; }
    }
}
