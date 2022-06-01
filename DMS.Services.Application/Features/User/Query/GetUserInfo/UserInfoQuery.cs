using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Services.Application.Features
{
   public class UserInfoQuery : IRequest<UserInfoVM>
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
