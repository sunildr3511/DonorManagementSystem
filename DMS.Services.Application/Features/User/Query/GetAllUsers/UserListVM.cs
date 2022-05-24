using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class UserListVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Department { get; set; }

        public int ReportingManagerCode { get; set; }

        public string ReportingManagerName { get; set; }

        public string ReportingManagerEmail { get; set; }

        public string ReportingManagerMobile { get; set; }

        public int RoleId { get; set; }

        public int LocationId { get; set; }

        public int CenterId { get; set; }

        public string Zone { get; set; }

        public bool IsActive { get; set; }

        public string RoleName { get; set; }

        public string LocationName { get; set; }

        public string CenterName { get; set; }
    }
}
