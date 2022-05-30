using DMS.Services.Application.Contracts.Persistence;
using DMS.Services.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Persistence.Repositories
{
    public class UserInfoRepository : BaseRepository<UserInfo>, IUserInfoRepository
    {
        private readonly DMSAppDbContext _dmsAppDBContext;
        public UserInfoRepository(DMSAppDbContext dmsAppDBContext) : base(dmsAppDBContext)
        {
            _dmsAppDBContext = dmsAppDBContext;
        }

        public async Task<List<UserInfo>> FetchLoggedInUserInfo(string userName, string email)
        {
            var result = await _dmsAppDBContext.UserInfo.Where(x => x.Name.ToLower() == userName.ToLower() &&
                                                                    x.Email.ToLower() == email.ToLower()).Select(p => new UserInfo 
                                                                                { Id =p.Id,Name =p.Name,RoleId=p.RoleId,LocationId =p.LocationId,CenterId =p.CenterId}).ToListAsync<UserInfo>();

            return result ;

        }
    }
}
