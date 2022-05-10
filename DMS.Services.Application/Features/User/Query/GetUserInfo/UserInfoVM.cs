using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class UserInfoVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int RoleId { get; set; }

        public int LocationId { get; set; }

        public int CenterId { get; set; }
    }
}
