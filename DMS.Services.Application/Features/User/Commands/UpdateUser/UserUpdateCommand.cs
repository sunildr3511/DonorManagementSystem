using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class UserUpdateCommand : IRequest<string>
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

        public int UpdatedBy { get; set; }

        public bool IsDelete { get; set; }
    }
}
