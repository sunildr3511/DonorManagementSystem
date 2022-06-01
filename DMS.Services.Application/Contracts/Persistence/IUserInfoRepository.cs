using DMS.Services.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Application.Contracts.Persistence
{
   public interface IUserInfoRepository : IAsyncRepository<UserInfo>
    {
        Task<UserInfo> FetchLoggedInUserInfo(string userName,string email);

        Task<bool> ValidateDuplicateUserInfoOnAdd(string email);

        Task<bool> ValidateDuplicateUserInfoOnUpdate(string email,int userId);
    }
}
